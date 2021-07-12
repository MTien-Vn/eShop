import Vue from 'vue'
import Router from 'vue-router'
import { Role } from '../helper/Enum'
import DashboardLayout from '@/layout/DashboardLayout'
//import AuthLayout from '@/layout/AuthLayout'
// import store from './store/index'

import System from "@/views/System/SystemLayout.vue";
import ImportedItemLayout from "@/views/ImportedItem/ImportedItemLayout.vue";
import SellingItem from "@/views/SellingItem/SellingItemLayout.vue";
import Vendor from "@/views/ImportedItem/Vendor.vue";
import Item from "@/views/ImportedItem/Item.vue";
import Invoice from "@/views/ImportedItem/Invoice.vue";

Vue.use(Router)


export const router = new Router({
    mode: 'history',
    linkExactActiveClass: 'active',
    routes: [{
            path: '/',
            redirect: 'dashboard',
            component: DashboardLayout,
            meta: {
                authRequired: true
            },
            children: [{
                    path: '/dashboard',
                    name: 'dashboard',
                    // route level code-splitting
                    // this generates a separate chunk (about.[hash].js) for this route
                    // which is lazy-loaded when the route is visited.
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/Dashboard.vue'),
                    meta: {
                        authRequired: true
                    }
                },
                {
                    path: '/icons',
                    name: 'icons',
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/Icons.vue'),
                    meta: {
                        authRequired: true
                    }
                },
                {
                    path: '/profile',
                    name: 'profile',
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/UserProfile.vue'),
                    meta: {
                        authRequired: false
                    }
                },
                {
                    path: '/maps',
                    name: 'maps',
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/Maps.vue'),
                    meta: {
                        authRequired: true
                    }
                },
                {
                    path: '/tables',
                    name: 'tables',
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/Tables.vue'),
                    meta: {
                        authRequired: true
                    }
                },
                {
                    path: "system",
                    name: "System",
                    component: System,
                    meta: { authorize: [Role.Admin] }
                },
                {
                    path: "importedItem",
                    name: "ImportedItem",
                    component: ImportedItemLayout,
                    children: [{
                            path: "vendor",
                            name: "Vendor",
                            component: Vendor
                        },
                        {
                            path: "item",
                            name: "Item",
                            component: Item
                        },
                        {
                            path: "invoice",
                            name: "Invoice",
                            component: Invoice
                        }
                    ]
                },
                {
                    path: "sellingItem",
                    name: "Selling Item",
                    component: SellingItem
                },
            ]
        },
        // {
        //     path: '/',
        //     redirect: 'login',
        //     component: AuthLayout,
        //     children: [{
        //             path: '/login',
        //             name: 'login',
        //             component: () =>
        //                 import ( /* webpackChunkName: "demo" */ '../views/Login.vue'),
        //             meta: {
        //                 authRequired: false
        //             }
        //         },
        //         {
        //             path: '/register',
        //             name: 'register',
        //             component: () =>
        //                 import ( /* webpackChunkName: "demo" */ '../views/Register.vue'),
        //             meta: {
        //                 authRequired: false
        //             }
        //         }
        //     ]
        // },
        {
            path: "/login",
            name: "Login",
            component: () =>
                import ( /* webpackChunkName: "demo" */ '../views/System/Login/Login.vue'),
        },
        {
            path: "/register",
            name: "register",
            component: () =>
                import ( /* webpackChunkName: "demo" */ '../views/System/Login/Register.vue'),
        },
        {
            path: "*",
            redirect: "/login"
        }
    ]
})


// router.beforeEach((to, from, next) => {

//     if (to.meta.authRequired == true) {
//         if (!store.getters.isAuthenticated) {
//             next({ name: 'login' })
//         }
//         else {
//             next();
//         }
//     }
//     else {
//         next();
//     }
// });

router.beforeEach((to, from, next) => {
    // chuyển đến trang login nếu chưa được login
    const publicPages = ['/login', '/register'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('user');

    if (authRequired && !loggedIn) {
        return next('/login');
    }
    const { authorize } = to.meta;
    var user = JSON.parse(loggedIn);

    if (authorize) {
        // check if route is restricted by role
        if (authorize.length && !authorize.includes(user.roles.toString())) {
            // role not authorised so redirect to home page
            return next({ path: '/' });
        }
    }

    next();
})


export default router;