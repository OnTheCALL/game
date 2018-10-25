﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Todo
{
    public class ScriptsParser
    {
        private string _filePath;
        private string _text;
        private string[] _tags;

        public ScriptsParser(string filePath, string[] tags = null)
        {
            _filePath = filePath;
            var file = new FileInfo(_filePath);
            if (file.Exists)
                _text = File.ReadAllText(filePath);
            _tags = tags;
        }

        public TodoEntry[] Parse()
        {
            var file = new FileInfo(_filePath);
            if (!file.Exists)
                return null;
            var temp = new List<TodoEntry>();
            foreach (var tag in _tags)
            {
                var regex = new Regex(string.Format(@"(?<=\W|^)//(\s?{0})(.*)", tag), RegexOptions.IgnoreCase);
                var matches = regex.Matches(_text);
                temp.AddRange(
                    from Match match in matches
                    let text = match.Groups[2].Value
                    let line = IndexToLine(match.Index)
                    select new TodoEntry(text, "", tag, _filePath, line));
            }
            return temp.ToArray();
        }

        private int IndexToLine(int index)
        {
            return _text.Take(index).Count(c => c == '\n') + 1;
        }
    } 
}
