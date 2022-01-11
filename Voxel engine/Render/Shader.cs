﻿using GLFW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenGL.GL;

namespace Voxel_engine.Render
{
    internal class Shader
    {
        int type;
        uint shader;
        string fileName;
        string source;
        public Shader(int type, string path)
        {
            this.type = type;
            this.fileName = path;
            shader = glCreateShader(type);
            source = File.ReadAllText(path);
            Console.WriteLine("OpenGL version is {0} ", glGetString(GL_VERSION)); 
            Console.WriteLine(source);
            glShaderSource(shader, source);
            
            glCompileShader(shader);

            int success = glGetShaderiv(shader, GL_COMPILE_STATUS, 1)[0];
            if (success == GL_FALSE)
            {
                Console.Write("ERROR::SHADER::" + fileName + "::COMPILATION_FAILED\n" + glGetShaderInfoLog(shader));
            }
        }
        public uint GetShader()
        {
            return shader;
        }
        public void Free()
        {
            glDeleteShader(shader);
        }
    }
}