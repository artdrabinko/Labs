using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests
{
    [TestClass()]
    public class DatabaseTests
    {

        [TestMethod()]
        public void UserConstructorAllParamTest()
        {
            
            //arrange Вводи входные значени и значения которые ожидаем получить
            string input_name = "Ibragimov K.V.";
            string input_servece = "Massage";
            int input_cost = 55;

            string expected_name = "Ibragimov K.V.";
            string expected_servece = "Massage";
            int expected_cost = 55;

            Patient patient = new Patient(input_name, input_servece, input_cost);


            //act Получаем актуальные значения
            string actual_name = patient.name;
            string actual_servece = patient.service;
            int actual_cost = patient.cost;


            //assert Проверяем при помощи класса Assert
            Assert.AreEqual(expected_name, actual_name, "Patient name {0} should have been {1}!", actual_name, expected_name);
            Assert.AreEqual(expected_servece, actual_servece, "Service {0} should have been {1}!", actual_servece, expected_servece);
            Assert.AreEqual(expected_cost, actual_cost, "Cost {0} should have been {1}!", actual_cost, expected_cost);
        }


        [TestMethod()]
        public void addNewPatientInDBCorrectParamTest()
        {
            Patient patient = new Patient("Petrov G.V.", "Massage", 40);

            Database database = new Database();

            //Проверяем добавился ли наш пациент в БД.
            Assert.IsTrue(database.addNewPatientInDatabase(patient));
        }


        [TestMethod()]
        public void addNewPatientInDBWrongParamTest()
        {
            Patient patient = new Patient();

            Database database = new Database();

            //Не указали информацию о пользователе, ожидаем ошибку добавления.
            Assert.IsFalse(database.addNewPatientInDatabase(patient));
        }


        [TestMethod()]
        public void deletePatientByNumberFromDBTest()
        {
            Patient patient = new Patient("Petrov G.V.", "Massage", 40);

            Database database = new Database();
            database.addNewPatientInDatabase(patient);

            //В базе только 1 пользователь удаление должно пройти успешно
            Assert.IsTrue(database.deletePatientByNumber("1"));
        }

        [TestMethod()]
        public void deletePatientByNumberFromEmptyDBTest()
        {
            Patient patient = new Patient("Petrov G.V.", "Massage", 40);

            Database database = new Database();

            //В базе не пользователей удаление не произдет должно прийти значение false
            Assert.IsFalse(database.deletePatientByNumber("1"));
        }

        [TestMethod()]
        public void viewAllPatientsEmptyListTest()
        {
            Database database = new Database();

            //В базе не пользователей при просмотре должно прийти значение false
            Assert.IsFalse(database.viewAllPatients());
        }

        [TestMethod()]
        public void viewAllPatientsNotEmptyListTest()
        {
            Database database = new Database();
            Patient patient = new Patient("Petrov G.V.", "Yzi", 40);

            database.addNewPatientInDatabase(patient);

            //В базе есть пользователь результат просмотра должен пройти успешно
            Assert.IsTrue(database.viewAllPatients());
        }


    }
}