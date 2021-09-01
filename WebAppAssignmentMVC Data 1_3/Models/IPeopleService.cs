﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);

        PeopleViewModel All();

        PeopleViewModel FindBy(PeopleViewModel search);

        Person FindBy(int id);

        Person Edit(int id, Person person);

        bool Remove(int id);
    }
}
