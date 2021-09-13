﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel createLanguageViewModel);

        LanguageViewModel All();

        LanguageViewModel FindBy(LanguageViewModel search);

        Language FindBy(int id);

        Language Edit(int id, Language language);

        bool Remove(int id);

        void CreateBaseLanguages();

    }
}