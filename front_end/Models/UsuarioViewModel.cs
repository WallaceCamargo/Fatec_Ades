﻿namespace front_end.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? CPF { get; set; }
        public string? Password { get; set; }
        public string? ConfirmedPassword { get; set; }
        public string? TokensendEmail { get; set; }

    }
}
