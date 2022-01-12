import React, { Component } from 'react';
import { Route } from 'react-router';
import { Routes, BrowserRouter } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import { ApplicationPaths, LoginActions, LogoutActions } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'
import { Login } from './components/api-authorization/Login';
import { Logout } from './components/api-authorization/Logout';

const HelpApp = React.lazy(
 () => import('HELP/Help')
);

function App() {
    return (
        <div>
              <BrowserRouter>
                    <Layout>
                        <Routes>
                            <Route path="/" element={<Home />} />
                            <Route path={ApplicationPaths.Register} element={<Login action={LoginActions.Register}/>} />
                            <Route path={ApplicationPaths.Login} element={<Login action={LoginActions.Login}/>} />
                            <Route path={ApplicationPaths.LoginCallback} element={<Login action={LoginActions.LoginCallback}/>} />
                            <Route path={ApplicationPaths.LoginFailed} element={<Login action={LoginActions.LoginFailed}/>} />
                            <Route path={ApplicationPaths.Profile} element={<Login action={LoginActions.Profile}/>} />
                            <Route path={ApplicationPaths.LogOut} element={<Logout action={LogoutActions.Logout}/>} />
                            <Route path={ApplicationPaths.LogOutCallback} element={<Logout action={LogoutActions.LogoutCallback}/>} />
                            <Route path={ApplicationPaths.LoggedOut} element={<Logout action={LogoutActions.LoggedOut}/>} />
                        </Routes>
                    </Layout>                            
                </BrowserRouter>
                <React.Suspense fallback='Loading...'>
                    <HelpApp />
                </React.Suspense>
            
        </div>
    );
}

export default App;




//import React from 'react';
// import './App.css';
// const ProductApp = React.lazy(
//  () => import('PRODUCT/Test')
// );
// const App = () => (
//  <div className="App">
//    <h2>Hi from Shell App</h2>
//     <React.Suspense fallback='Loading...'>
//      <ProductApp />
//    </React.Suspense>
//  </div>
// );
// export default App;