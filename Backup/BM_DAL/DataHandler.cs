using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;

namespace Web0204.BM.DAL
{
    /// <summary>
    /// /// <summary>
    /// DataHandler���ṩ���ݿ⽻������������
    /// </summary>
    /// </summary>
    public abstract class DataHandler : IDataHandler
    {
        protected string connectionString;

        #region --- Query���� ---
        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        ///<returns>���ز�ѯ������ݱ�</returns>
        public DataTable Query(string commandText)
        {
            return this.Query(commandText, null, 0, 0);
        }
        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <returns>���ز�ѯ������ݱ�</returns>
        public DataTable Query(string commandText, IList parameters)
        {
            return this.Query(commandText, parameters, 0, 0);
        }

        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="start">��ѯ����ʼ��������</param>
        /// <param name="max">��ҳ�Ĵ�С</param>
        /// <returns>���ز�ѯ������ݱ�</returns>
        public DataTable Query(string commandText, int start, int max)
        {
            return this.Query(commandText, null, start, max);
        }
        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <param name="start">��ѯ����ʼ��������</param>
        /// <param name="max">��ҳ�Ĵ�С</param>
        /// <returns>���ز�ѯ������ݱ�</returns>
        public abstract DataTable Query(string commandText, IList parameters, int start, int max);

        #endregion

        #region --- ExecuteCommand���� ---
        /// <summary>
        /// ִ�и��²���������
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        public bool ExecuteCommand(string commandText)
        {
            return this.ExecuteCommand(commandText, null);
        }
        /// <summary>
        /// ִ�и��²���������
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        public abstract bool ExecuteCommand(string commandText, IList parameters);

        #endregion

        #region ---- ExecuteBatchCommand���� ---
        /// <summary>
        /// ����ִ�и��²���������
        /// </summary>
        /// <param name="commandTexts">�����ı�����</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        public bool ExecuteBatchCommand(IList commandTexts)
        {
            return ExecuteBatchCommand(commandTexts, null);
        }

        /// <summary>
        /// ����ִ�и��²���������
        /// </summary>
        /// <param name="commandTexts">�����ı�����</param>
        /// <param name="parameters">������������������</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        public abstract bool ExecuteBatchCommand(IList commandTexts, IList parameters);

        #endregion

        /// <summary>
        /// �������ݿ⽻������
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="dbType">���ݿ��������</param>
        /// <returns></returns>
        public static IDataHandler CreateHandler(string connectionString, DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.OleDb:

                    return new OleDbDataHandler(connectionString);

                case DatabaseType.Sql:

                    return new SqlDataHandler(connectionString);

                default:

                    return new SqlDataHandler(connectionString);
            }
        }

        /// <summary>
        /// �������ݿ⽻������,Ĭ��ΪSql
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="dbType">���ݿ��������</param>
        public static IDataHandler CreateHandler(string connectionString)
        {
            return new SqlDataHandler(connectionString);
        }

        /// <summary>
        /// ���������ļ���������Ϣ���������ݿ⽻������
        /// </summary>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="dbType">���ݿ��������</param>
        public static IDataHandler CreateHandler()
        {
            string dbType = ConfigurationManager.AppSettings["DbType"].ToLower();

            DatabaseType type = DatabaseType.Sql;
            if (dbType == "oledb")
            {
                type = DatabaseType.OleDb;
            }
            else if (dbType == "oracle")
            {
                type = DatabaseType.Oracle;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["BM_Connection"].ConnectionString;

            return CreateHandler(connectionString, type);
        }

        /// <summary>
        /// �ͷ�ָ���������Դ
        /// </summary>
        /// <param name="obj"></param>
        protected void Dispose(IDisposable obj)
        {
            if (obj != null)
            {
                obj.Dispose();
                obj = null;
            }
        }
    }
}
