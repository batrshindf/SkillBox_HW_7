using System;

namespace SkillBox_HW_7
{
    internal struct Employee
    {
        #region Конструкторы

        /// <summary>
        ///     Создание записи Сотрудника
        /// </summary>
        /// <param name="id">ID сотрудника</param>
        /// <param name="dataTimeRecordAdd">Дата и время создания сотрудника</param>
        /// <param name="fullName">Ф.И.О.</param>
        /// <param name="age">Возраст</param>
        /// <param name="height">Рост</param>
        /// <param name="dateOfBirth">Дата Рождения</param>
        /// <param name="placeOfBirth">Место рождения</param>
        public Employee(int id, DateTime dataTimeRecordAdd, string fullName, int age, int height,
            DateTime dateOfBirth, string placeOfBirth)
        {
            this._id = id;
            this._dataTimeRecordAdd = dataTimeRecordAdd;
            this._fullName = fullName;
            this._age = age;
            this._height = height;
            this._dateOfBirth = dateOfBirth;
            this._placeOfBirth = placeOfBirth;
        }

        /// <summary>
        ///     Создание записи Сотрудника
        /// </summary>
        /// <param name="fullName">Ф.И.О.</param>
        /// <param name="age">Возраст</param>
        /// <param name="height">Рост</param>
        /// <param name="dateOfBirth">Дата Рождения</param>
        public Employee(string fullName, int age, int height, DateTime dateOfBirth) :
            this(10000, DateTime.Now, fullName, age, height, dateOfBirth, "Null")
        {
        }

        /// <summary>
        ///     Создание записи Сотрудника
        /// </summary>
        /// <param name="fullName">Ф.И.О.</param>
        /// <param name="age">Возраст</param>
        /// <param name="height">Рост</param>
        public Employee(string fullName, int age, int height) :
            this(fullName, age, height, new DateTime(1643, 1, 4))
        {
        }

        /// <summary>
        ///     Создание записи Сотрудника
        /// </summary>
        /// <param name="fullName">Ф.И.О.</param>
        /// <param name="age">Возраст</param>
        public Employee(string fullName, int age) :
            this(fullName, age, 0)
        {
        }

        /// <summary>
        ///     Создание записи Сотрудника
        /// </summary>
        /// <param name="fullName">Ф.И.О.</param>
        public Employee(string fullName) :
            this(fullName, 0)
        {
        }

        #endregion

        #region Свойства

        /// <summary>
        ///     ID сотрудника
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        ///     Дата и время добавления завписи
        /// </summary>
        public DateTime DataTimeRecordAdd
        {
            get => _dataTimeRecordAdd;
            private set => _dataTimeRecordAdd = value;
        }

        /// <summary>
        ///     Ф.И.О.
        /// </summary>
        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        /// <summary>
        ///     Возраст
        /// </summary>
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        /// <summary>
        ///     Рост
        /// </summary>
        public int Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        ///     Дата родждения
        /// </summary>
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }

        /// <summary>
        ///     Место рождения
        /// </summary>
        public string PlaceOfBirth
        {
            get => _placeOfBirth;
            set => _placeOfBirth = value;
        }

        #endregion

        #region Параметры

        /// <summary>
        ///     ID сотрудника
        /// </summary>
        private int _id;

        /// <summary>
        ///     Дата и время добавления завписи
        /// </summary>
        private DateTime _dataTimeRecordAdd;

        /// <summary>
        ///     Ф.И.О.
        /// </summary>
        private string _fullName;

        /// <summary>
        ///     Возраст
        /// </summary>
        private int _age;

        /// <summary>
        ///     Рост
        /// </summary>
        private int _height;

        /// <summary>
        ///     Дата родждения
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        ///     Место рождения
        /// </summary>
        private string _placeOfBirth;

        #endregion

        public string Print()
        {
            return $"{_id,6} {_dataTimeRecordAdd,18:dd.MM.yyyy hh:mm} {_fullName,30} {_age,5} {_height,7} " +
                   $"{_dateOfBirth,15:dd.MM.yyyy} {_placeOfBirth,15}";
        }
        public string PrintToFile()
        {
            return $"{_id}#{_dataTimeRecordAdd:dd.MM.yyyy hh:mm}#{_fullName}#{_age}#{_height}#{_dateOfBirth:dd.MM.yyyy}" +
                   $"#{_placeOfBirth}";
        }
    }
}