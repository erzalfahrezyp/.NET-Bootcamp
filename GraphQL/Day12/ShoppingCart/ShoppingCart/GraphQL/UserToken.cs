﻿namespace ShoppingCart.GraphQL
{
    public class UserToken
    {
        public string Token { get; set; }
        public string ExpiredAt { get; set; }
        public string Message { get; set; }
    }
}
