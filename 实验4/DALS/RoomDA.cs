using System;

namespace DALS
{
    public class RoomDA
    {
        DataTable dt = new DataTable("rooms");
        public RoomDA()
        {

            DataWork.ds.Tables.Add(dt);
            dt.Columns.Add("房间名", Type.GetType("System.String"));
            dt.Columns.Add("所在楼宇", Type.GetType("System.String"));
            dt.Columns.Add("所在楼层", Type.GetType("System.String"));
            dt.Columns.Add("房间号", Type.GetType("System.String"));
            dt.Columns.Add("房间类型", Type.GetType("System.String"));
            dt.Columns.Add("说明", Type.GetType("System.String"));
            dt.Columns.Add("状态", Type.GetType("System.String"));
            dt.Columns.Add("定价", Type.GetType("System.String"));
        }

        public string AddRoom(Models.Room room)
        {

            if (IsRoomExist(room))
                return "该房间已经-存在！";
            DataRow row = dt.NewRow();
            row[0] = room.RoomName;
            row[1] = room.BuildingName;
            row[2] = room.Floor;
            row[3] = room.Num;
            row[4] = room.RoomType;
            row[5] = room.Memo;
            row[6] = room.RoomStatus;
            dt.Rows.Add(row);
            return "添加成功|";
        }

        public bool IsRoomExist(Models.Room room)
        {
            bool flag = false;
            foreach (DataRow dr in dt.Rows)
                if (room.RoomName == dr[0].ToString()) { flag = true; break; }
            return flag;
        }
    }
}
