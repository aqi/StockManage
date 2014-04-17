using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace Web0204.BM.DAL
{
    class OleDbDataHandler : DataHandler
    {
        public OleDbDataHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 将通用的参数对象转换成OleDbParameter类型的对象
        /// </summary>
        /// <param name="parameter">通用的参数对象</param>
        /// <returns></returns>
        private OleDbParameter ToOleDbParameter(object objParameter)
        {
            OleDbParameter result = new OleDbParameter();
            DataParameter parameter = (DataParameter)objParameter;
            result.ParameterName = parameter.ParameterName;
            result.DbType = parameter.DbType;
            result.Value = parameter.Value;
            return result;
        }

        /// <summary>
        /// 初始化命令对象
        /// </summary>
        /// <param name="connector">数据源对象</param>
        /// <param name="commandText">命令文本</param>
        /// <param name="parameters">参数对象容器</param>
        /// <returns></returns>
        private OleDbCommand InitializeCommand(OleDbConnection connector, string commandText, IList parameters)
        {
            OleDbCommand commander = new OleDbCommand(commandText, connector);
            if (parameters != null && parameters.Count > 0)
            {
                for (int index = 0; index < parameters.Count; index++)
                {
                    commander.Parameters.Add(this.ToOleDbParameter(parameters[index]));
                }
            }
            return commander;
        }

        public override DataTable Query(string commandText, IList parameters, int start, int max)
        {
            OleDbConnection connector = new OleDbConnection(connectionString);
            OleDbCommand commander = this.InitializeCommand(connector, commandText, parameters);
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
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
            OleDbConnection connector = new OleDbConnection(connectionString);
            OleDbCommand commander = this.InitializeCommand(connector, commandText, parameters);
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
            OleDbConnection connector = new OleDbConnection(connectionString);
            OleDbCommand commander = new OleDbCommand();

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
                            commander.Parameters.Add(this.ToOleDbParameter(parameterList[count]));
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
