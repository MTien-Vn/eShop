import axios from 'axios';
import { baseUrl } from '../configConnection.json'
import { authHeader } from '../helper/auth-helper';

export const HTTP = axios.create({
        baseURL: baseUrl,
        headers: {
            Authorization: authHeader()
        }
    })
    // cach dung
    // import {HTTP} from './http-common';

// export default {
//   data() {
//     return {
//       posts: [],
//       errors: []
//     }
//   },

//   created() {
//     HTTP.get(`posts`)
//     .then(response => {
//       this.posts = response.data
//     })
//     .catch(e => {
//       this.errors.push(e)
//     })
//   }
// }