using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Web0204.BM.DAL
{
    /// <summary>
    /// IDataHandler�ӿ��ṩ�����ݿ⽻������������
    /// </summary>
    public interface IDataHandler
    {
        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        ///<returns>���ز�ѯ������ݱ�</returns>
        DataTable Query(string commandText);

        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <returns>���ز�ѯ������ݱ�</returns>
        DataTable Query(string commandText, IList parameters);
        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="start">��ѯ����ʼ��������</param>
        /// <param name="max">��ҳ�Ĵ�С</param>
        /// <returns>���ز�ѯ������ݱ�</returns>
        DataTable Query(string commandText, int start, int max);

        /// <summary>
        /// ִ�в�ѯ����
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <param name="start">��ѯ����ʼ��������</param>
        /// <param name="max">��ҳ�Ĵ�С</param>
        /// <returns>���ز�ѯ������ݱ�</returns>
        DataTable Query(string commandText, IList parameters, int start, int max);

        /// <summary>
        /// ִ�и��²���������
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        bool ExecuteCommand(string commandText);
        /// <summary>
        /// ִ�и��²���������
        /// </summary>
        /// <param name="commandText">�����ı�</param>
        /// <param name="parameters">������������</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        bool ExecuteCommand(string commandText, IList parameters);

        /// <summary>
        /// ����ִ�и��²���������
        /// </summary>
        /// <param name="commandTexts">�����ı�����</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        bool ExecuteBatchCommand(IList commandTexts);

        /// <summary>
        /// ����ִ�и��²���������
        /// </summary>
        /// <param name="commandTexts">�����ı�����</param>
        /// <param name="parameters">������������������</param>
        /// <returns>ִ�гɹ�����true,���򷵻�false</returns>
        bool ExecuteBatchCommand(IList commandTexts, IList parameters);

    }
}
