using System;
using System.Collections.Generic;

namespace Assessment.Models.DTO
{
    //This is a generic paging DTO that can return a list of any type of object.
    public class ResultDTO<T>
    {
        public List<T> results;

        public double NumberOfSearchResults {get; set;}
        public int Page {get; set;}
        public int PageSize {get; set;}
        public double NumberOfPages { get; set; }
    }
}
