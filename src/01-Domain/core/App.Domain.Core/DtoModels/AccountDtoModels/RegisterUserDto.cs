﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Core.DtoModels.AccountDtoModels
{
    public class RegisterUserDto
    {

        public string Email { get; set; }


        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
