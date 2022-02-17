using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vaccinator {
    /// <summary>
    /// Загрузка и хранение статистики заболеваемости за последние три дня с сайта стопкоронавирус.рф
    /// </summary>
    class CovidStat {
        private static CovidStat instance;
        private static readonly Regex regex = new Regex(@"(\d*),");

        private DateTime createTime;
        private int[] sicks;

        //=============================================GETTERS/SETTERS=======================================

        /// <summary>
        /// Возвращает количество заболевших за предыдущие три дня
        /// </summary>
        public int[] Sicks {
            get {
                return (int[])sicks.Clone();
            }
        }

        //===============================================CONSTRUCTOR=========================================

        /// <summary>
        /// Парсит статистику заболеваемости коронавирусом по Курганской области с сайта стопкоронавирус.рф
        /// </summary>
        private CovidStat() {
            this.createTime = DateTime.Now;
            this.sicks = new int[3];

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebRequest request = WebRequest.Create("https://xn--80aesfpebagmfblc0a.xn--p1ai/covid_data.json?do=region_stats&code=RU-KGN");
            WebResponse response = request.GetResponse();
            string json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            
            for (int i = 0, index = 0; i < sicks.Length; ++i, ++index) {
                index = json.IndexOf("sick", index);
                this.sicks[i] = this.getNum(json, index);
            }
        }

        //==============================================METHODS=======================================

        /// <summary>
        /// Статический метод для создания/получения объекта текущего класса
        /// </summary>
        /// <returns>Объект CovidStat</returns>
        public static CovidStat GetInstance() {
            if (instance == null || instance.createTime.Date != DateTime.Now.Date)
                instance = new CovidStat();
            return instance;
        }


        /// <summary>
        /// Поиск числа в заданном тексте формата JSON начиная с определённого индекса
        /// </summary>
        /// <param name="text">Текст формата JSON, для поиска числа</param>
        /// <param name="startIndex">Индекс, с которого следует начинать поиск</param>
        /// <returns>Первое найденное число</returns>
        private int getNum(string text, int startIndex) {
            return int.Parse(regex.Match(text.Substring(startIndex)).Value.TrimEnd(','));
        }
    }
}
