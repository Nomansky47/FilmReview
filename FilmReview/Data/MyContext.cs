﻿using FilmReview.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FilmReview.Data
{
    public partial class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        [JsonIgnore]
        public DbSet<Users>? Users { get; set; }
        [JsonIgnore]
        public DbSet<Films>? Films { get; set; }
        [JsonIgnore]
        public DbSet<Videos>? Videos { get; set; }
        [JsonIgnore]
        public DbSet<Comments>? Comments { get; set; }
        [JsonIgnore]
        public DbSet<Reviews>? Reviews { get; set; }
        [JsonIgnore]
        public DbSet<Likes>? Likes { get; set; }
        [JsonIgnore]
        public DbSet<Dislikes>? Dislikes { get; set; }
    }
}