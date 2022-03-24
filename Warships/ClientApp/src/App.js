import React, { Component, useEffect, useState  } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Test } from './components/Test';

import './custom.css'

const App = () => {
   
    return <div className='app'>
        <h2>MyChat</h2>
        <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={FetchData} />
            <Route path='/test' component={Test} />
        </Layout>
        <hr className='line' />
    </div>
}

export default App;
