import React, { Component } from 'react';
import "./DealCard.css";

export default function DealCard(props){
    const deal = props.deal;
    return(
    <div className={"deal-card"}>
        <div>
            <div>{deal.taskName}</div>
            <div>
                {deal.priority}
            </div>
        </div>
        <div>
            {deal.dateTime}
        </div>
    </div>)
}