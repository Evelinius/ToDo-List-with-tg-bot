import React, { Component } from 'react';
import "./Counter.css"

export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = 
    { 
      taskName: "",
      priority: "",
      date: undefined,
      time: undefined,

    };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  handleSubmitButtonClick = async () => {
    const splitted = this.state.date.split('-')
    const splittedTime = this.state.time.split(":")
    const dateTime = new Date(splitted[2], splitted[1], splitted[0], splittedTime[0], splittedTime[1], 0, 0)
    const request = {
      taskName: this.state.taskName,
      priority: this.state.priority,
      dateTime: dateTime
    };
    const options = {
      method: "POST",
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
      body: JSON.stringify(request)
    }
    const response = await fetch('/tasks/add', options);
  }

  priorities = [
    "Важная",
    "Обычная",
    "Побочная"
  ]

  handleChange = (event) => {
    this.setState({taskName: event.target.value});
  }

  handleSelect = (event) => {
    this.setState({priority: event.target.value})
  }

  handleDateChange = (event) => {
    this.setState({date: event.target.value})
  }
  handleTimeChange = (event) => {
    this.setState({time: event.target.value})
  }
  render() {
    let { taskName, priority, date, time } = this.state;
    return (
      <div>
        <h1>
          Добавить задачу
        </h1>
        <hr/>
        <dic>
          <h2>Название</h2>
            <input type="text" value={taskName} onChange={this.handleChange}></input>
          <h2>Приоритет</h2>
          <select value={priority} onChange={this.handleSelect}>
            {this.priorities.map((p) => <option>{p}</option>)}
          </select>
          <input onChange={this.handleDateChange} value={date}  type="date" id="start" name="trip-start"></input>
          <input onChange={this.handleTimeChange} value={time}  type="time" id="start" name="trip-start"></input>
          <div>
            <button onClick={this.handleSubmitButtonClick}>Добавить</button>
          </div>
        </dic>
      </div>
    );
  }
}
