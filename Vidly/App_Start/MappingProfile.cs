﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //automapper will use reflection to infer types and map them.

            //mapping customer and customerDto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            //mapping movie and movieDto
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            //mapping membershipType and membershipTypeDto
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //mapping genre to genreDto
            Mapper.CreateMap<Genre, GenreDto>();

            //mapping movie and movieFormViewModel
            Mapper.CreateMap<Movie, MovieFormViewModel>();
            Mapper.CreateMap<MovieFormViewModel, Movie>();

            //mapping customer to customerFormViewModel and vice-versa.
            Mapper.CreateMap<Customer, CustomerFormViewModel>();
            Mapper.CreateMap<CustomerFormViewModel, Customer>();
        }
    }
}