using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphWinForms
{
    public class Vertex<T>:ICloneable where T : ICloneable
    {
        public int Id { get; set; }
        public T Data { get; set; }

        public Vertex()
        {
            Id = -1;
            Data = default(T);
        }

        public Vertex(int id)
        {
            Id = id;
            Data = Data = default(T);
        }

        public Vertex(int id, T data)
        {
            Id = id;
            Data = data;
        }

        public override bool Equals(object obj)
        {
            Vertex<T> vertexToCheck = (Vertex<T>)obj;
            return this.Id == vertexToCheck.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return "[" + Id.ToString() + "]";
        }

        public object Clone()
        {
            return new Vertex<T>(Id = this.Id, Data = (T)this.Data.Clone());
        }
    }
}
