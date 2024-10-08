import React, { useEffect, useState } from 'react';
import './App.css';

interface User {
    id: string;
    firstName: string;
    lastName: string;
    userName: string;
    email: string;
}

// UserList component to fetch and display users
const UserList: React.FC = () => {
    const [users, setUsers] = useState<User[]>([]);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await fetch('https://localhost:7227/api/User'); // Replace with your actual API endpoint
                if (response.ok) {
                    const data = await response.json();
                    setUsers(data);
                } else {
                    console.error('Failed to fetch users');
                }
            } catch (error) {
                console.error('Error:', error);
            }
        };

        fetchUsers();
    }, []);

    return (
        <div>
            <h2>User List</h2>
            <ul>
                {users.map(user => (
                    <li key={user.id}>
                        {user.firstName} {user.lastName} ({user.userName}) - {user.email}
                    </li>
                ))}
            </ul>
        </div>
    );
}

// Main App component
function App() {
    return (
        <div>
            <h1>User Management</h1>
            <p>This component demonstrates fetching and displaying user data from the server.</p>
            <UserList />
        </div>
    );
}

export default App;