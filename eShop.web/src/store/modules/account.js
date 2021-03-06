import { userService } from '../../service/userService.js';
import { router } from '../../router/router';
import { setAuthHeader } from "../modules/axiosHeaders";

const user = JSON.parse(localStorage.getItem('user'));
const state = user ? {
    status: { loggedIn: true },
    user
} : {
    status: {},
    user: null
};

const getters = {
    StateUser: (state) => state.user,
    Token: (state) => state.user.token,
};

const actions = {
    login({ dispatch, commit }, { user_name, pass_word }) {
        userService.login(user_name, pass_word)
            .then(
                response => {
                    commit('loginSuccess', response);
                    commit("setToken", response.token);
                    router.push('/');
                },
                error => {
                    commit('loginFailure', error);
                    dispatch('alert/error', error, { root: true });
                }
            );
    },
    logout({ commit }) {
        userService.logout();
        commit('logout');
        // router.push('/login');
    },
    register({ dispatch, commit }, user) {
        commit('registerRequest', user);

        userService.register(user)
            .then(
                user => {
                    commit('registerSuccess', user);
                    router.push('/login');
                    setTimeout(() => {
                        // hiển thị message thành công sau redirect sang trang 
                        dispatch('alert/success', 'Registration successful', { root: true });
                    })
                },
                error => {
                    commit('registerFailure', error);
                    dispatch('alert/error', error, { root: true });
                }
            );
    },
    checkToken({ dispatch, commit }) {

        let token = this.getters.Token;
        if (!token) {
            dispatch("logout");
        } else {
            commit("setToken", token);
        }
    }
};

const mutations = {
    loginSuccess(state, user) {
        state.status = { loggedIn: true };
        state.user = user;
    },
    loginFailure(state) {
        state.status = {};
        state.user = null;
    },
    logout(state) {
        state.status = {};
        state.user = null;
    },
    registerRequest(state) {
        state.status = { registering: true };
    },
    registerSuccess(state) {
        state.status = {};
    },
    registerFailure(state) {
        state.status = {};
    },
    setToken(state, token) {
        //state.token = token;
        setAuthHeader(token);
    }
};

export const account = {
    namespaced: true,
    state,
    actions,
    mutations,
    getters
};