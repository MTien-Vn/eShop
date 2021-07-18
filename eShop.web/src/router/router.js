import Vue from 'vue'
import Router from 'vue-router'
import { Role } from '../helper/Enum'
//import AuthLayout from '@/layout/AuthLayout'
// import store from './store/index'


Vue.use(Router)


export const router = new Router({
    mode: 'history',
    linkExactActiveClass: 'active',
    routes: [{
            path: '/',
            redirect: 'dashboard',
            component: () =>
                import ( /* webpackChunkName: "demo" */ '@/layout/DashboardLayout'),
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
                        import ( /* webpackChunkName: "demo" */ '../views/Dashboard/Dashboard.vue'),
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
                        import ( /* webpackChunkName: "demo" */ '../views/UserProfile/UserProfile.vue'),
                    meta: {
                        authRequired: false
                    }
                },
                // {
                //     path: '/maps',
                //     name: 'maps',
                //     component: () =>
                //         import ( /* webpackChunkName: "demo" */ '../views/Maps.vue'),
                //     meta: {
                //         authRequired: true
                //     }
                // },
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
                    path: "/system",
                    name: "System",
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/System/SystemLayout.vue'),
                    meta: { authorize: [Role.Admin] }
                },
                {
                    path: "/importItem",
                    name: "ImportedItem",
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/ImportedItem/ImportedItemLayout.vue'),
                    children: [{
                            path: "vendor",
                            name: "Vendor",
                            component: () =>
                                import ( /* webpackChunkName: "demo" */ '../views/ImportedItem/VendorList.vue'),
                            meta: { authorize: [Role.Admin] }
                        },
                        {
                            path: "item",
                            name: "Item",
                            component: () =>
                                import ( /* webpackChunkName: "demo" */ '../views/ImportedItem/ItemList.vue'),
                        },
                        {
                            path: "invoice",
                            name: "Invoice",
                            component: () =>
                                import ( /* webpackChunkName: "demo" */ '../views/ImportedItem/InvoiceList.vue'),
                        }
                    ]
                },
                {
                    path: "/sellingItem",
                    name: "Selling Item",
                    component: () =>
                        import ( /* webpackChunkName: "demo" */ '../views/Tables.vue'),
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
            alert("You dont have permission to access. Ask admin to get it !")
                // role not authorised so redirect to home page
            return next(from);
        }
    }

    next();
})


export default router;