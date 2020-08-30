import React, { Component } from 'react'

export class Settings extends Component{
    constructor(props){
        super(props)
        this.state = {
            guid: ""
        }
    }

    render(){
        return (
        <div>
            Для регистрации необходимо начать общение с телеграм <a href={"t.me/TodoListProjectBot"}>ботом</a>
        </div>)
    }
}