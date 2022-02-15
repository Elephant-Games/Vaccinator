using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vaccinator.Exceptions;

namespace Vaccinator {
    class Parser {
        private static readonly Regex regex = new Regex(@"http(s?)://(\w+)(\w*)\.(\w+)(\w*)"); //TODO: защита от нескольких вхождений

        private string url;
        private string htmlCode;
        private string htmlElem;
        private List<string> results;

        private int lastCursorPos;
        private int cursorPos;

        //===============================================GETTERS/SETTERS===================================================

        public string Url {
            get {
                return this.url;
            }

            set {
                if (regex.Matches(url).Count == 1) //TODO: протестировать защиту от нескольких вхождений URL
                    this.url = value;
                else
                    throw new InvalidUrlException($"URL \"{value}\" is incorrect");
            }
        }

        public List<string> Results {
            get {
                return new List<string>(this.results);
            }
        }

        //=================================================CONSTRUCTORS====================================================

        public Parser(string url, string htmlElem) {
            this.Url = url;
            this.htmlElem = htmlElem;

            htmlCode = (new System.Net.WebClient()).DownloadString(url);
            results = new List<string>();
            lastCursorPos = 0;
            cursorPos = 0;
        }

        //====================================================METHODS======================================================
        //-----------------------------------------------------PUBLIC------------------------------------------------------

        /// <summary>
        /// Функция для парсинга сайта
        /// </summary>
        /// <returns>Список с результатами парсинга</returns>
        public List<string> Parse() {
            for (; this.cursorPos < this.htmlCode.Length; ++this.cursorPos) {
                if (this.htmlCode[this.cursorPos] == '<') {
                    this.lastCursorPos = ++this.cursorPos;
                    if (this.findElem())
                        results.Add(getData(getBlockName()));
                }
            }
            return this.Results;
        }

        //----------------------------------------------------PRIVATE------------------------------------------------------

        /// <summary>
        /// Ищет блок с заданным названием элемента (например id или class)
        /// </summary>
        /// <returns>true, если такой блок найден</returns>
        private bool findElem() {
            return this.findElem(this.htmlElem);
        }

        /// <summary>
        /// Ищет блок с заданным названием элемента (например id или class)
        /// </summary>
        /// <param name="htmlElem">Название элемента для поиска</param>
        /// <returns>true, если такой блок найден</returns>
        private bool findElem(string htmlElem) {
            int tempCursorPos = 0;
            for (; this.cursorPos < this.htmlCode.Length; ++this.cursorPos, tempCursorPos = 0) {
                for (; this.htmlCode[this.cursorPos] == htmlElem[tempCursorPos]; ++this.cursorPos, ++tempCursorPos) {
                    if (tempCursorPos == htmlElem.Length - 1)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Получение названия текущего блока HTML
        /// </summary>
        /// <returns>строка с названием блока</returns>
        private string getBlockName() {
            StringBuilder blockName = new StringBuilder();
            for (; this.lastCursorPos < this.htmlCode.Length && this.htmlCode[this.lastCursorPos] != ' '; ++this.lastCursorPos)
                blockName.Append(this.htmlCode[this.lastCursorPos]);
            return blockName.ToString();
        }

        /// <summary>
        /// Считывание заданных данных из HTML
        /// </summary>
        /// <param name="blockName">Блок, данные которого нужно считать</param>
        /// <returns>строка с заданными данными</returns>
        private string getData(string blockName) {
            StringBuilder data = new StringBuilder();
            while (this.cursorPos < this.htmlCode.Length && this.htmlCode[this.cursorPos] != '>')
                ++this.cursorPos;
            this.lastCursorPos = ++this.cursorPos;
            if (findElem("</" + blockName)) {
                for (; this.lastCursorPos < this.cursorPos - ("</" + blockName).Length; ++this.lastCursorPos)
                    data.Append(this.htmlCode[this.lastCursorPos]);
            }
            return data.ToString();
        }
    }
}
