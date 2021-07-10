import { userService } from '../../service/userService.js';
import { router } from '../../routes/routes';

const user = JSON.parse(localStorage.getItem('user'));
const state = user ? {
    status: { loggedIn: true },
    user
} : {
    status: {},
    user: null
};

const actions = {
    login({ dispatch, commit }, { user_name, pass_word }) {
        commit('loginRequest', { user_name });

        userService.login(user_name, pass_word)
            .then(
                response => {
                    commit('loginSuccess', response);
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
        router.push('/login');
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
    }
};

const mutations = {
    loginRequest(state, user) {
        state.status = { loggingIn: true };
        state.token_user = user;
    },
    loginSuccess(state, user) {
        state.status = { loggedIn: true };
        state.user = user.token;
    },
    loginFailure(state) {
        state.status = {};
        state.user = null;
    },
    logout(state) {
        state.status = {};
        state.user = null;
    },
    registerRequest(state, user) {
        state.status = { registering: true };
    },
    registerSuccess(state, user) {
        state.status = {};
    },
    registerFailure(state, error) {
        state.status = {};
    }
};

export const account = {
    namespaced: true,
    state,
    actions,
    mutations
};