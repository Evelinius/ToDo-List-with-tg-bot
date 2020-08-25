import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData as SettingsComponent } from './components/FetchData';
import { Counter as CreateTaskComponent } from './components/Counter';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/create-task' component={CreateTaskComponent} />
        <Route path='/settings' component={SettingsComponent} />
      </Layout>
    );
  }
}
