﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorfun_bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Frame
    {
        private int _score;

        public int Score()
        {
            return _score;
        }

        public void Add(int pins)
        {
            _score += pins;
        }
    }
}
