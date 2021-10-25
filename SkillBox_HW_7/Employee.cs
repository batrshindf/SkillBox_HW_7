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
            this.id = id;
            this.dataTimeRecordAdd = dataTimeRecordAdd;
            this.fullName = fullName;
            this.age = age;
            this.height = height;
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
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
            get => id;
            set => id = value;
        }

        /// <summary>
        ///     Дата и время добавления завписи
        /// </summary>
        public DateTime DataTimeRecordAdd
        {
            get => dataTimeRecordAdd;
            private set => dataTimeRecordAdd = value;
        }

        /// <summary>
        ///     Ф.И.О.
        /// </summary>
        public string FullName
        {
            get => fullName;
            set => fullName = value;
        }

        /// <summary>
        ///     Возраст
        /// </summary>
        public int Age
        {
            get => age;
            set => age = value;
        }

        /// <summary>
        ///     Рост
        /// </summary>
        public int Height
        {
            get => height;
            set => height = value;
        }

        /// <summary>
        ///     Дата родждения
        /// </summary>
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => dateOfBirth = value;
        }

        /// <summary>
        ///     Место рождения
        /// </summary>
        public string PlaceOfBirth
        {
            get => placeOfBirth;
            set => placeOfBirth = value;
        }

        #endregion

        #region Параметры

        /// <summary>
        ///     ID сотрудника
        /// </summary>
        private int id;

        /// <summary>
        ///     Дата и время добавления завписи
        /// </summary>
        private DateTime dataTimeRecordAdd;

        /// <summary>
        ///     Ф.И.О.
        /// </summary>
        private string fullName;

        /// <summary>
        ///     Возраст
        /// </summary>
        private int age;

        /// <summary>
        ///     Рост
        /// </summary>
        private int height;

        /// <summary>
        ///     Дата родждения
        /// </summary>
        private DateTime dateOfBirth;

        /// <summary>
        ///     Место рождения
        /// </summary>
        private string placeOfBirth;

        #endregion

        public string Print()
        {
            return $"{id,6} {dataTimeRecordAdd,18:dd.MM.yyyy hh:mm} {fullName,30} {age,5} {height,7} {dateOfBirth,15:dd.MM.yyyy} {placeOfBirth,15}";
        }
    }
}