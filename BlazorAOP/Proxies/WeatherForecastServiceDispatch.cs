using BlazorAOP.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Reflection;

namespace BlazorAOP.Proxies
{
    public class WeatherForecastServiceDispatch<T> : DispatchProxy
    {
        public T Target { get; set; } = default!;
        private FakeAuthenticationStateProvider _auth = default!;

        public static T? Create<T>(T target, FakeAuthenticationStateProvider auth) where T : class
        {
            var proxy = Create<T, WeatherForecastServiceDispatch<T>>() as WeatherForecastServiceDispatch<T>;
            proxy!.Target = target;
            proxy._auth = auth;
            return proxy as T;
        }

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            if (!_auth.IsAuthenticated) throw new InvalidOperationException("Invocation failed: User not authenticated");

            return targetMethod!.Invoke(Target, args);
        }
    }
}
