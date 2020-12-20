﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMO_G9.model;

namespace LMO_G9.dto
{
    public class CategoryDto : Category
    {
        private string createPeople;
        private string updatePeople;

        public CategoryDto()
        {

        }

        public CategoryDto(string createPeople, string updatePeople)
        {
            this.CreatePeople = createPeople;
            this.UpdatePeople = updatePeople;
        }
        public string CreatePeople { get => createPeople; set => createPeople = value; }
        public string UpdatePeople { get => updatePeople; set => updatePeople = value; }
    }
}