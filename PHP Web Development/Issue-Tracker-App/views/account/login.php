<h1>Login</h1>

<form method="post" action="/account/login">
    <label for="username">Username: </label>
    <input type="text" name="username" id="username"/>
    <br/>
    <label for="password">Password: </label>
    <input type="password" name="password" id="password"/>
    <br/>
    <input type="submit" value="Login"/>
    <a href="/account/register">[Register]</a>
</form>