﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore
{
    internal interface IBookRepository
    {
        Book[] GetAllByTitle(string titlePart);
    }
}
