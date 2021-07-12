import { baseUrl } from '../configConnection.json'
import { authHeader } from '../helper/auth-helper';
import axios from 'axios';

export const userService = {
    login,
    logout,
    register,
    getAll,
    getById,
    update,
    delete: _delete
};

async function login(user_name, pass_word) {
    // const requestOptions = {
    //     method: 'POST',
    //     headers: { 'Content-Type': 'application/json' },
    //     body: JSON.stringify({ user_name, pass_word })
    // };

    // return fetch(`${baseUrl}/Users/authenticate`, requestOptions)
    //     .then(handleResponse)
    //     .then(user => {
    //         // login thành công nếu có một token jwt trong response
    //         if (user.data) {
    //             // lưu dữ liệu user và token jwt vào local storage để giữ user được log in trong page
    //             localStorage.setItem('user', JSON.stringify(user));
    //         }

    //         return user;
    //     });

    var rs = await axios.post(baseUrl + '/Users/authenticate', {
        user_name: user_name,
        pass_word: pass_word
    });
    var response = rs.data;
    if (response.misaCode !== 200) {
        logout();
        //location.reload(true);
        alert(response.messenger);
        return;
    }

    localStorage.setItem('user', JSON.stringify(response.data));
    return response.data;
}

function logout() {
    // xoá user từ local storage để log out
    localStorage.removeItem('user');
}

function register(user) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    };

    return fetch(`${baseUrl}/Users/register`, requestOptions).then(handleResponse);
}

function getAll() {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };

    return fetch(`${baseUrl}/users`, requestOptions).then(handleResponse);
}


function getById(id) {
    const requestOptions = {
        method: 'GET',
        headers: authHeader()
    };

    return fetch(`${baseUrl}/users/${id}`, requestOptions).then(handleResponse);
}

function update(user) {
    const requestOptions = {
        method: 'PUT',
        headers: {...authHeader(), 'Content-Type': 'application/json' },
        body: JSON.stringify(user)
    };

    return fetch(`${baseUrl}/Users/${user.id}`, requestOptions).then(handleResponse);
}

function _delete(id) {
    const requestOptions = {
        method: 'DELETE',
        headers: authHeader()
    };

    return fetch(`${baseUrl}/Users/${id}`, requestOptions).then(handleResponse);
}

function handleResponse(response) {
    return response.text().then(text => {
        const data = text && JSON.parse(text);

        if (response.misaCode !== 200) {
            // tự động logout nếu response k thanh cong được trả về từ api
            logout();
            location.reload(true);
            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }

        return data;
    });
}

// export default {
//     login
// }