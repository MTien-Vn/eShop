import Vue from 'vue';
import Router from 'vue-router';
import { Role } from '../helper/Enum';

import DashboardLayout from "@/pages/Layout/DashboardLayout.vue";

import Dashboard from "@/pages/Dashboard.vue";
import System from "@/pages/System/Users.vue";
import TableList from "@/pages/TableList.vue";
import Typography from "@/pages/Typography.vue";
import Icons from "@/pages/Icons.vue";
import Notifications from "@/pages/Notifications.vue";
import ImportedItemLayout from "@/pages/ImportedItem/ImportedItemLayout.vue";
import SellingItem from "@/pages/SellingItem/SellingItemLayout.vue";
import Vendor from "@/pages/ImportedItem/Vendor.vue";
import Item from "@/pages/ImportedItem/Item.vue";
import Invoice from "@/pages/ImportedItem/Invoice.vue";
import Login from "@/pages/Login/Login.vue";
import Register from "@/pages/Login/Register.vue";
import UserProfile from "@/pages/UserProfile/UserProfile.vue";

Vue.use(Router);

export const router = new Router({
    mode: 'history',
    routes: [{
            path: "/",
            component: DashboardLayout,
            redirect: "/dashboard",
            children: [{
                    path: "dashboard",
                    name: "Dashboard",
                    component: Dashboard
                },
                {
                    path: "profile",
                    name: "Profile",
                    component: UserProfile
                },
                {
                    path: "system",
                    name: "System",
                    component: System,
                    meta: { authorize: [Role.Admin] }
                },
                {
                    path: "table",
                    name: "Table List",
                    component: TableList
                },
                {
                    path: "importedItemLayout",
                    name: "Imported Item",
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
                    path: "sellingItemLayout",
                    name: "Selling Item",
                    component: SellingItem
                },
                {
                    path: "typography",
                    name: "Typography",
                    component: Typography
                },
                {
                    path: "icons",
                    name: "Icons",
                    component: Icons
                },
                {
                    path: "notifications",
                    name: "Notifications",
                    component: Notifications
                }
            ]
        },
        {
            path: "/login",
            name: "Login",
            component: Login,
        },
        {
            path: "/register",
            name: "register",
            component: Register
        },
        {
            path: "*",
            redirect: "/login"
        }
    ]
});

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