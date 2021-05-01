import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios'; 
import { Header, List } from 'semantic-ui-react';

function App() {

  const [activities,setActivities] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:44351/api/Activities').then(response=>{
      console.log(response.data);
      setActivities(response.data);
    })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />
        <List>
          {activities.map((activity:any) =>(
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
