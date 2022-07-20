using System.Collections;

namespace Building
{
    public class Creator
    {
        public static Hashtable buildings = new Hashtable();
        public static Building CreatorBuild()
        {
            var building = new Building();
            buildings.Add(building.NumberBuilding, building);
            return building;
        }
        public static Building CreatorBuild(byte floors, byte entrances)
        {
            var building = new Building(floors, entrances);
            buildings.Add(building.NumberBuilding, building);
            return building;
        }
        public static Building CreatorBuild(byte floors, byte entrances, ushort aparts)
        {
            var building = new Building(floors, entrances, aparts);
            buildings.Add(building.NumberBuilding, building);
            return building;
        }
        public static Building CreatorBuild(ushort height, byte floors, byte entrances, ushort aparts)
        {
            var building = new Building(height, floors, entrances, aparts);
            buildings.Add(building.NumberBuilding, building);
            return building;
        }
        private Creator() { }//требование было сделать конструктор закрытым, для того, чтобы нельзя было создать объект класса? других причин я не нашёл.
        /// <summary>
        /// Представляет хэш-таблицу buildings в виде строки
        /// </summary>
        /// <returns>хэш-таблицу buildings в виде строки</returns>
        public static string PrintTable()
        {
            string table = string.Empty;
            ICollection keys = buildings.Keys;
            foreach (var key in keys)
            {
                table += $"{key}: {buildings[key]}\n";
            }
            return table;
        }
        /// <summary>
        /// Удаляет дом по номеру дома
        /// </summary>
        /// <param name="key">номер дома(ключ)</param>
        public static void DeleteBuild(uint key)
        {
            buildings.Remove(key);
        }
    }
}
