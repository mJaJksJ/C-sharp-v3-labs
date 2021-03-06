﻿using System;
using System.Collections.Generic;

namespace ResearchBase
{
    /// <summary>
    /// Paper, with fields title, author and date of publication
    /// </summary>
    [Serializable]
    class Paper: IComparable, IComparer<Paper>
    {
        /// <value>get/set title</value>
        public string Title { get; set; }
        /// <value>get/set author</value>
        public Person Author { get; set; }
        /// <value>get/set date of publication</value>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_title">title of paper</param>
        /// <param name="_author">author of paper</param>
        /// <param name="_publicationDate">date of publication of paper</param>
        public Paper(string _title, Person _author, DateTime _publicationDate)
        {
            this.Title = _title;
            this.Author = _author;
            this.PublicationDate = _publicationDate;
        }

        /// <summary>
        /// default constructor Paper("Title", new Person(), DateTime.MinValue)
        /// </summary>
        public Paper()
        {
            this.Title = "Title";
            this.Author = new Person();
            this.PublicationDate = DateTime.MinValue;
        }

        /// <summary>
        /// convert fields of paper in string
        /// </summary>
        /// <returns>string with title, author and date of publication</returns>
        public override string ToString()
        {
            return Title + " /author:" + Author.ToString() + "/ " + PublicationDate.ToShortDateString();
        }

        /// <summary>
        /// Copy by value
        /// </summary>
        /// <returns>object with common fields as this</returns>
        public virtual object DeepCopy()
        {
            return new Paper(Title, (Person)Author.DeepCopy() ,PublicationDate);
        }

        /// <summary>
        /// compare by publication date
        /// </summary>
        /// <param name="obj">compared object</param>
        /// <exception cref="System.Exception">Невозможно сравнить два объекта</exception>
        /// <returns>this.PublicationDate.CompareTo(obj.PublicationDate)</returns>
        public int CompareTo(object obj)
        {
            if (obj is Paper paper)
                return this.PublicationDate.CompareTo(paper.PublicationDate);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        /// <summary>
        /// compare by publication title
        /// </summary>
        /// <param name="p1">first compared object</param>
        /// <param name="p2">second compared object</param>
        /// <returns></returns>
        public int Compare(Paper p1, Paper p2)
        {
            return p1.Title.CompareTo(p2.Title);
        }
    

    }
}
