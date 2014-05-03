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
    /// WarehouseProvider���ʾ���ģ������Ĺ�����
    /// </summary>
    public class WarehouseProvider : ActionBase
    {
        #region --- Insert���� ---

        /// <summary>
        /// ���һ���µĿ��
        /// </summary>
        /// <param unit="warehouse">�µĿ��</param>
        /// <returns>��ӳɹ�����true,���򷵻�false</returns>
        public bool Insert(Warehouse warehouse)
        {
            if (warehouse.Warehouse_number == 0)
            {
                return false;
            }

            try
            {
                string commandText = "INSERT INTO t_warehouse VALUES (@good_id,@warehouse_type,@warehouse_number,@warehouse_time,@order_id,@warehouse_operators)";

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_id";
                parmGood.DbType = DbType.Int32;
                parmGood.Value = warehouse.Good_id;

                DataParameter parmType = new DataParameter();
                parmType.ParameterName = "@warehouse_type";
                parmType.DbType = DbType.String;
                parmType.Value = warehouse.Warehouse_type;

                DataParameter parmNumber = new DataParameter();
                parmNumber.ParameterName = "@warehouse_number";
                parmNumber.DbType = DbType.Int32;
                parmNumber.Value = warehouse.Warehouse_number;

                DataParameter parmTime = new DataParameter();
                parmTime.ParameterName = "@warehouse_time";
                parmTime.DbType = DbType.DateTime;
                parmTime.Value = warehouse.Warehouse_time;

                DataParameter parmOrderID = new DataParameter();
                parmOrderID.ParameterName = "@order_id";
                parmOrderID.DbType = DbType.Int32;
                parmOrderID.Value = warehouse.Order_id;

                DataParameter parmOperators = new DataParameter();
                parmOperators.ParameterName = "@warehouse_operators";
                parmOperators.DbType = DbType.String;
                parmOperators.Value = warehouse.Warehouse_operators;

                IList parameters = new ArrayList();
                parameters.Add(parmGood);
                parameters.Add(parmType);
                parameters.Add(parmNumber);
                parameters.Add(parmTime);
                parameters.Add(parmOrderID);
                parameters.Add(parmOperators);

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
        /// �޸Ŀ�������
        /// </summary>
        /// <param name="warehouse">�µĿ��</param>
        /// <returns>�޸ĳɹ�����true,���򷵻�false</returns>
        public bool Update(Warehouse warehouse)
        {
            if (warehouse.Warehouse_id == 0)
            {
                return false;
            }

            string commandText = " UPDATE  t_warehouse " +
                                  " SET good_id=@good_id,warehouse_type=@warehouse_type,warehouse_number=@warehouse_number ,warehouse_time=@warehouse_time r,warehouse_operators=@warehouse_operators  " +
                                     " WHERE warehouse_id=@warehouse_id ";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Warehouse_id;

            DataParameter parmGood = new DataParameter();
            parmGood.ParameterName = "@good_id";
            parmGood.DbType = DbType.Int32;
            parmGood.Value = warehouse.Good_id;

            DataParameter parmType = new DataParameter();
            parmType.ParameterName = "@warehouse_type";
            parmType.DbType = DbType.String;
            parmType.Value = warehouse.Warehouse_type;

            DataParameter parmNumber = new DataParameter();
            parmNumber.ParameterName = "@warehouse_number";
            parmNumber.DbType = DbType.Int32;
            parmNumber.Value = warehouse.Warehouse_number;

            DataParameter parmTime = new DataParameter();
            parmTime.ParameterName = "@warehouse_time";
            parmTime.DbType = DbType.DateTime;
            parmTime.Value = warehouse.Warehouse_time;

            DataParameter parmOperators = new DataParameter();
            parmOperators.ParameterName = "@warehouse_operators";
            parmOperators.DbType = DbType.String;
            parmOperators.Value = warehouse.Warehouse_type;

            IList parameters = new ArrayList();
            parameters.Add(parmID);
            parameters.Add(parmGood);
            parameters.Add(parmType);
            parameters.Add(parmNumber);
            parameters.Add(parmTime);
            parameters.Add(parmOperators);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion

        #region --- Select���� ---

        /// <summary>
        /// ����ָ���Ĺ���������ѯ���
        /// </summary>
        /// <param name="warehouse">��������</param>
        /// <returns></returns>
        public DataTable Select(Warehouse warehouse)
        {
            return this.Select(warehouse, 0, 0);
        }

        /// <summary>
        /// ���÷�ҳ����,����ָ���Ĺ���������ѯ���
        /// </summary>
        /// <param name="warehouse">��������</param>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable Select(Warehouse warehouse, int start, int max)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM t_warehouse warehouses,t_good goods WHERE warehouses.good_id=goods.good_id ");
            IList parameters = new ArrayList();

            if (warehouse.Warehouse_id != 0)
            {
                commandText.Append(" AND warehouse_id=@warehouse_id ");
                DataParameter parmID = new DataParameter();
                parmID.ParameterName = "@warehouse_id";
                parmID.DbType = DbType.Int32;
                parmID.Value = warehouse.Warehouse_id;
                parameters.Add(parmID);

            }

            if (warehouse.Good_id != 0)
            {
                commandText.Append(" AND warehouses.good_id=@good_id ");

                DataParameter parmGood = new DataParameter();
                parmGood.ParameterName = "@good_id";
                parmGood.DbType = DbType.Int32;
                parmGood.Value = warehouse.Good_id;
                parameters.Add(parmGood);
            }

            if (!String.IsNullOrEmpty(warehouse.Warehouse_type))
            {
                commandText.Append(" AND warehouse_type=@warehouse_type ");

                DataParameter parmType = new DataParameter();
                parmType.ParameterName = "@warehouse_type";
                parmType.DbType = DbType.String;
                parmType.Value = warehouse.Warehouse_type;
                parameters.Add(parmType);
            }

            return this.handler.Query(commandText.ToString(), parameters, start, max);
        }

        #endregion

        #region --- GetAll���� ---

        /// <summary>
        /// ��ȡ���еĿ���¼
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string commandText = "SELECT * FROM t_warehouse warehouses,t_good goods WHERE warehouses.good_id=goods.good_id ";
            return this.handler.Query(commandText);
        }
        /// <summary>
        /// ���÷�ҳ���ƻ�ȡ���еĿ���¼
        /// </summary>
        /// <param name="start">��ʼ��</param>
        /// <param name="max">��ȡ��¼�е�����</param>
        /// <returns></returns>
        public DataTable GetAll(int start, int max)
        {
            string commandText = "SELECT * FROM t_warehouse warehouses,t_good goods WHERE warehouses.good_id=goods.good_id ";
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
            string commandText = "SELECT Count(warehouse_id) FROM t_warehouse";
            DataTable table = this.handler.Query(commandText);
            if (table != null && table.Rows.Count > 0)
            {
                return Convert.ToInt32(table.Rows[0][0]);
            }
            return 0;
        }

        /// <summary>
        /// ��ȡ�����ϸID������
        /// </summary>
        /// <param name="warehouse">�����Ϣ</param>
        /// <returns></returns>
        public int GetSize(Warehouse warehouse)
        {
            string commandText = "SELECT Count(warehouse_id) FROM t_warehouse WHERE good_id=@good_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@good_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Good_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

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
        /// ɾ��ָ���Ŀ���¼
        /// </summary>
        /// <param name="warehouse">��Ҫ��ɾ���Ŀ���¼</param>
        /// <returns>ɾ���ɹ�����true,���򷵻�false</returns>
        public bool Delete(Warehouse warehouse)
        {
            if (warehouse.Warehouse_id == 0)
            {
                return false;
            }
            string commandText = "DELETE FROM t_warehouse WHERE warehouse_id=@warehouse_id";

            DataParameter parmID = new DataParameter();
            parmID.ParameterName = "@warehouse_id";
            parmID.DbType = DbType.Int32;
            parmID.Value = warehouse.Warehouse_id;

            IList parameters = new ArrayList();
            parameters.Add(parmID);

            return this.handler.ExecuteCommand(commandText, parameters);
        }

        #endregion 
    }
}
