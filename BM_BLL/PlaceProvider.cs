using System;
using System.Collections.Generic;
using System.Text;
using Web0204.BM.DAL;
using Web0204.BM.Info;
using System.Collections;
using System.Data;

namespace Web0204.BM.BLL
{
    /// <summary>
    /// PlaceProvider���ʾ��λģ������Ĺ�����
    /// </summary>
    public class PlaceProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĿ�λ
        /// </summary>
        /// <param unit="place">�µĿ�λ</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Place place)
        {
            if (String.IsNullOrEmpty(place.Place_num))
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_place VALUES (@place_num,@place_state)";

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@place_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = place.Place_num;

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@place_state";
                parmState.DbType = DbType.String;
                parmState.Value = place.Place_state;

                IList parameters = new ArrayList();
                parameters.Add(parmNum);
                parameters.Add(parmState);

                return this.handler.ExecuteCommand(commandText, parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        #endregion

        #region --- Update���� ---

        /// <summary>
        /// �޸Ŀ�λ������
        /// </summary>
        /// <param name="place">�µĿ�λ</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Place place)
        {
            if (place.Place_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_place " +
                                  " SET place_num=@place_num,place_state=@place_state " +
                                     " WHERE place_id=@place_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@place_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = place.Place_id;

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@place_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = place.Place_num;

            DataParameter parmState = new DataParameter();
            parmState.ParameterName = "@place_state";
            parmState.DbType = DbType.String;
            parmState.Value = place.Place_state;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmNum);
            parameters.Add(parmState);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ��λ
        /// </summary>
        /// <param name="place">��������</param>
        /// <returns></returns>
        public DataTable Select(Place place)
        {
            return this.Select(place, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ��λ
        /// </summary>
        /// <param name="product">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Place place, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_place WHERE 1=1 ");
            IList parameters = new ArrayList();

            if (place.Place_id != 0)
            {
                commandText.Append(" AND place_id=@place_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@place_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = place.Place_id;
                parameters.Add(parmID);

            }

            if ( false == String.IsNullOrEmpty(place.Place_num))
            {
                commandText.Append(" AND place_num like  @place_num ");

                DataParameter parmNum = new DataParameter();
                parmNum.ParameterName = "@place_num";
                parmNum.DbType = DbType.String;
                parmNum.Value = place.Place_num;
                parameters.Add(parmNum);
            }

            if ( false == String.IsNullOrEmpty(place.Place_state))
            {
                commandText.Append(" AND place_state like  @place_state ");

                DataParameter parmState = new DataParameter();
                parmState.ParameterName = "@place_state";
                parmState.DbType = DbType.String;
                parmState.Value = place.Place_state;
                parameters.Add(parmState);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĿ�λ��¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_place";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĿ�λ���¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_place";
            return this.handler.Query(commandText, start, max);
        }

        #endregion

        #region --- GetSize���� ---

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            string commandText = "SELECT Count(place_id) FROM t_place";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ��λ���������
        /// </summary>
        /// <param name="place">��λ���</param>
        /// <returns></returns>
        public int GetSize(Place place)
        {
            string commandText = "SELECT Count(place_id) FROM t_place WHERE place_num like @place_num";

            DataParameter parmNum = new DataParameter();
            parmNum.ParameterName = "@place_num";
            parmNum.DbType = DbType.String;
            parmNum.Value = place.Place_num;

            IList parameters = new ArrayList();
            parameters.Add(parmNum);

            DataTable table = this.handler.Query(commandText, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        #endregion

        #region --- Delete���� ---

        /// <summary>
        /// ɾ��ָ���Ŀ�λ
        /// </summary>
        /// <param name="place">��Ҫ��ɾ���Ŀ�λ</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
        public bool Delete(Place place)
        {
            if (place.Place_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_place WHERE place_id=@place_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@place_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = place.Place_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
