﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asquell.Objects;

namespace Asquell
{
    public class MemoryBlock
    {
        private Dictionary<string, AsquellObj> _globals;
        private Dictionary<string, MemoryBlock> _scoped;
        public MemoryBlock()
        {
            _globals = new Dictionary<string, AsquellObj>();
            _scoped = new Dictionary<string, MemoryBlock>();
        }
        public void ModifyVariable(string name, AsquellObj value)
        {
            _globals[name] = value;
        }
        public void ModifyVariable(AsquellObj name, AsquellObj value)
        {
            if (name.Type == AsquellObjectType.RunTimeValue)
                ModifyVariable(name.Value.ToString(), value);
        }
        public AsquellObj GetVariable(string name)
        {
            return (_globals.ContainsKey(name) ? _globals[name] : null);
        }
        public AsquellObj GetVariable(AsquellObj name)
        {
            if (name.Type == AsquellObjectType.RunTimeValue)
                return GetVariable(name.Value.ToString());
            return null;
        }
        public void DeleteVariable(string name)
        {
            _globals.Remove(name);
        }
        public void DeleteVariable(AsquellObj name)
        {
            if (name.Type == AsquellObjectType.RunTimeValue)
                DeleteVariable(name.Value.ToString());
        }
        public bool CreateScope(string scope)
        {
            if (_scoped.ContainsKey(scope))
                return false;

            _scoped[scope] = new MemoryBlock();

            return true;
        }
        public MemoryBlock GetScope(string scope)
        {
            return (_scoped.ContainsKey(scope) ? _scoped[scope] : null);
        }
    }
}
