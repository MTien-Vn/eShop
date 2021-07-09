import { userService } from '../../service/userService.js';
import { router } from '../../routes/routes';

const token_user = JSON.parse(localStorage.getItem('token_user'));
const state = token_user ? { status: { loggedIn: true }, token_user } : { status: {}, token_user: null };

const actions = {
    login({ dispatch, commit }, { user_name, pass_word }) {
        commit('loginRequest', { user_name });

        userService.login(user_name, pass_word)
            .then(
                token_user => {
                    commit('loginSuccess', token_user);
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
    loginRequest(state, token_user) {
        state.status = { loggingIn: true };
        state.token_user = token_user;
    },
    loginSuccess(state, token_user) {
        state.status = { loggedIn: true };
        state.token_user = token_user;
    },
    loginFailure(state) {
        state.status = {};
        state.token_user = null;
    },
    logout(state) {
        state.status = {};
        state.token_user = null;
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