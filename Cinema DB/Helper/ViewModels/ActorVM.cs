﻿using Cinema_DB.Domain.Entities;

namespace Cinema_DB.Helper.ViewModels
{
    public class ActorVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<MovieVM> Movies { get; set; } 
    }
}
