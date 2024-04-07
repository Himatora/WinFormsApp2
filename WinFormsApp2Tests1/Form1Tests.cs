using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinFormsApp2.Form1;

namespace WinFormsApp2.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void delSymbTest()//удаление лишних символов
        {
            var str = "Ни грибы, ни мясо он не ел, хотя его брат утверждал обратное.";
            str = Logic.delSymb(str);
            Assert.AreEqual(str, "нигрибынимясооннеелхотяегобратутверждалобратное.");
        }
        [TestMethod()]
        //Проверка если есть одинаковые буквы
        public void searchSymbTest()//количество одинаковых букв соседей
        {
            var str = "нигрибынимясооннеелхотяегобратутверждалобратное.";
            int count = Logic.searchNeigh(str);
            Assert.AreEqual(3, count);
        }
        [TestMethod()]
        //Проверка если нет одинаковых букв
        public void searchSymb0Test()//количество одинаковых букв соседей
        {
            var str = "нигрибы.";
            int count = Logic.searchNeigh(str);
            Assert.AreEqual(0, count);
        }
        //Проверка, если написано одно предложение
        [TestMethod()]
        public void OneSentence()
        {
            var str = "Ни грибы, ни мясо он не ел, хотя его брат утверждал обратное.";
            int count = Logic.exam(str);
            Assert.AreEqual(1, count);
        }
        //2 повествовательных предложений
        public void TwoSentences()
        {
            var str = "Я люблю маму. Мама добрая.";
            int count = Logic.exam(str);
            Assert.AreEqual(2, count);
        }
        [TestMethod()]
        //2 типа предложения
        public void TwoAnotherSentences()
        {
            var str = "Я люблю маму! Мама добрая.";
            int count = Logic.exam(str);
            Assert.AreEqual(2, count);
        }
        [TestMethod()]
        //Вопросительное предложение
        public void SentencesQuation()
        {
            var str = "Я люблю маму?";
            int count = Logic.exam(str);
            Assert.AreEqual(1, count);
        }
        [TestMethod()]
        //Восклицательное предложение
        public void SentencesExclamation()
        {
            var str = "Я люблю маму!";
            int count = Logic.exam(str);
            Assert.AreEqual(1, count);
        }
        [TestMethod()]
        // 3 разных типа предложений
        public void ThreeAnotherSentences()

        {
            var str = "Я люблю маму! Мама добрая. А ты кто?";
            int count = Logic.exam(str);
            Assert.AreEqual(3, count);
        }
    }
}