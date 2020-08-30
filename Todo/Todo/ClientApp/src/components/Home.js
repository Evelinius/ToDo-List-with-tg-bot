import React, { Component } from 'react';
import DealCard from './DealCard'
export class Home extends Component {
  static displayName = Home.name;
  constructor(props){
    super(props);
    this.state = 
    { 
      deals: []
    }
  }

  async componentDidMount(){
    const options = {
      method: "GET",
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      }
    }
    const response = await fetch('/tasks', options);
    this.setState({deals: await response.json()});
    ;
  }

  render () {

    return (
      <div>
        {this.state.deals.map((d) => 
        <DealCard deal={d}/>
        )}
      </div>
    );
  }
}
