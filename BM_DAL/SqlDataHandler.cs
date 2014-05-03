using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Web0204.BM.DAL
{
    class SqlDataHandler : DataHandler
    {
        public SqlDataHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// ��ͨ�õĲ�������ת����SqlParameter���͵Ķ���
        /// </summary>
        /// <param name="parameter">ͨ�õĲ�������</param>
        /// <returns></returns>
        private SqlParameter ToSqlParameter(object objParameter)
        {
            SqlParameter result = new SqlParameter();
            DataParameter parameter = (DataParameter)objParameter;
            result.ParameterName = parameter.ParameterName;
            result.DbType = parameter.DbType;
            result.Value = parameter.Value;
            return result;
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        /// <param name="connector">����Դ����</param>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <returns></returns>
        private SqlCommand InitializeCommand(SqlConnection connector, string commandText, IList parameters)
        {
            SqlCommand commander = new SqlCommand(commandText, connector);
            if (parameters != null && parameters.Count > 0)
            {
                for (int index = 0; index < parameters.Count; index++)
                {
                    commander.Parameters.Add(this.ToSqlParameter(parameters[index]));
                }
            }
            return commander;
        }

        public override DataTable Query(string commandText, IList parameters, int start, int max)
        {
            SqlConnection connector = new SqlConnection(connectionString);
            SqlCommand commander = this.InitializeCommand(connector, commandText, parameters);
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = commander;
            try
            {
                if (max == 0)
                {
                    adapter.Fill(table);
                }
                else
                {
                    adapter.Fill(start, max, table);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose(connector);
                this.Dispose(commander);
                this.Dispose(adapter);
            }
            return table;
        }

        public override bool ExecuteCommand(string commandText, IList parameters)
        {
            SqlConnection connector = new SqlConnection(connectionString);
            SqlCommand commander = this.InitializeCommand(connector, commandText, parameters);
            int result = 0;
            try
            {
                if (connector.State != ConnectionState.Open)
                {
                    connector.Open();
                }
                result = commander.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connector.State != ConnectionState.Closed)
                {
                    connector.Close();
                }
                this.Dispose(connector);
                this.Dispose(commander);
            }
            return result > 0 ? true : false;
        }

        public override bool ExecuteBatchCommand(IList commandTexts, IList parameters)
        {
            if (commandTexts.Count != parameters.Count)
            {
                return false;
            }
            int[] results = new int[commandTexts.Count];
            SqlConnection connector = new SqlConnection(connectionString);
            SqlCommand commander = new SqlCommand();

            try
            {
                if (connector.State != ConnectionState.Open)
                {
                    connector.Open();
                }
                commander.Connection = connector;
                commander.Transaction = connector.BeginTransaction();


                for (int index = 0; index < commandTexts.Count; index++)
                {
                    commander.CommandText = Convert.ToString(commandTexts[index]);
                    IList parameterList = (IList)parameters[index];
                    if (parameterList != null && parameterList.Count > 0)
                    {
                        for (int count = 0; count < parameterList.Count; count++)
                        {
                            commander.Parameters.Add(this.ToSqlParameter(parameterList[count]));
                        }
                    }

                    results[index] = commander.ExecuteNonQuery();
                    commander.Parameters.Clear();

                }
                commander.Transaction.Commit();
            }
            catch (Exception ex)
            {
                commander.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (connector.State != ConnectionState.Closed)
                {
                    connector.Close();
                }
                this.Dispose(connector);
                this.Dispose(commander);
            }

            bool result = false;
            for (int index = 0; index < results.Length; index++)
            {
                if (results[index] <= 0)
                {
                    result = false;
                    break;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
