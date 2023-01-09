using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role_playing_game.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; } // ?  = setting return type to nullable
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}