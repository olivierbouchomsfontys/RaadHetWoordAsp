﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ExceptionLogRepository
    {
        private readonly IExceptionContext context;

        public ExceptionLogRepository(IExceptionContext context)
        {
            this.context = context;
        }

        public bool LogException(Exception e)
        {
            return context.LogException(e);
        }
    }
}
