namespace Building
{
    public class Building
    {
        private static uint _LastNumber;

        private uint _NumberBuilding;
        private double _Height;
        private byte _Floors;
        private byte _Entrances;
        private ushort _Aparts;
        private double _FloorHeight;

        #region Свойства
        public uint NumberBuilding
        {
            get
            {
                return this._NumberBuilding;
            }
            private set
            {
                this._NumberBuilding = value;
            }
        }
        public double Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                if (value < 2)
                    this._Height = 2;
                else
                {
                    this._Height = value;
                    if (this.Floors != default)
                    {
                        if (CulcFloorHeight() < 2)
                        {
                            throw new ArgumentException("Высота этажа должна быть больше 2 метров.");
                        }
                    }
                }
            }
        }
        public byte Floors
        {
            get
            {
                return this._Floors;
            }
            set
            {
                if (value < 1)
                    this._Floors = 1;
                else
                {
                    this._Floors = value;
                    if (this.Height != default)
                    {
                        if (CulcFloorHeight() < 2)
                        {
                            throw new ArgumentException("Высота этажа должна быть больше 2 метров.");
                        }
                    }
                }
            }
        }
        public byte Entrances
        {
            get
            {
                return this._Entrances;
            }
            set
            {
                if (value < 1)
                    this._Entrances = 1;
                else
                    this._Entrances = value;
            }
        }
        public ushort Aparts
        {
            get
            {
                return this._Aparts;
            }
            set
            {
                if (value < 2)
                    this._Aparts = 2;
                else
                    this._Aparts = value;
            }
        }
        #endregion

        internal Building()
        {
            this.NumberBuilding = SetUnicNumberBuilding();
        }

        internal Building(byte floors, byte entrances) : this()
        {
            this.Floors = floors;
            this.Entrances = entrances;
        }

        internal Building(byte floors, byte entrances, ushort aparts) : this()
        {
            this.Floors = floors;
            this.Entrances = entrances;
            this.Aparts = aparts;
        }

        internal Building(ushort height, byte floors, byte entrances, ushort aparts) : this()
        {
            this.Height = height;
            this.Floors = floors;
            this.Entrances = entrances;
            this.Aparts = aparts;
        }

        /// <summary>
        /// Метод вычисляет высоту этажа здания
        /// </summary>
        /// <returns>Возвращает высоту этажа</returns>
        /// <exception cref="Exception">Исключение, если высота этажа <2 метров </exception>
        public double CulcFloorHeight()// правильно ли будет этот метод вызвать сразу в конструкторе, если нам нужна такая логика: этаж > 2 метров?
        {
            return this.Height / this.Floors;
        }

        /// <summary>
        /// Метод вычисляет количество квартир в одном подъезде
        /// </summary>
        /// <returns>возвращает количество квартир в одном подъезде</returns>
        public int CulcNumbApartInEntrance()
        {
            return this.Aparts / this.Entrances;
        }

        /// <summary>
        /// Метод вычисляет количество квартир на одном этаже(во всех подъездах)
        /// </summary>
        /// <returns>количество квартир на одном этаже(во всех подъездах)</returns>
        /// <exception cref="Exception">Исключение, если на одном этаже меньше 2 квартар(в том числе и в 1 подъезде)</exception>
        public int CulcNumbApartPerFloor()
        {
            int numbApart = this.Aparts / this.Floors;
            if (numbApart < 2)
            {
                throw new Exception("Квартир на этаже не может быть меньше 2.");
            }
            else if (this.Entrances > 1 && numbApart / this.Entrances < 2)
            {
                throw new Exception("Квартир на этаже в одном подъезде не может быть меньше 2.");
            }
            else
            {
                return numbApart;
            }
        }

        /// <summary>
        /// Метод вычисляет количество квартир на одном этаже(в одном подъезде)
        /// </summary>
        /// <returns>Возвращает количество квартир на одном этаже(в одном подъезде)</returns>
        public int CulcNumbApartPerFloorInEntrance()
        {
            return CulcNumbApartPerFloor() / this.Entrances;
        }

        /// <summary>
        /// Метод увеличивает последний номер здания на 1. Присвает этот номер текущему зданию. Увеличивает статическую переменную на 1.
        /// </summary>
        /// <returns>Возвращает уникальный номер текущего здания.</returns>
        private uint SetUnicNumberBuilding()
        {
            return this.NumberBuilding = ++_LastNumber;
        }

        public override string ToString()
        {
            return $"Номер дома: {this.NumberBuilding}, высота: {this.Height}, этажей: {this.Floors}, квартир: {this.Aparts}";
        }
    }
}
