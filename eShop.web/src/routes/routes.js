import DashboardLayout from "@/pages/Layout/DashboardLayout.vue";

import Dashboard from "@/pages/Dashboard.vue";
import UserProfile from "@/pages/UserProfile.vue";
import TableList from "@/pages/TableList.vue";
import Typography from "@/pages/Typography.vue";
import Icons from "@/pages/Icons.vue";
import Maps from "@/pages/Maps.vue";
import Notifications from "@/pages/Notifications.vue";
import UpgradeToPRO from "@/pages/UpgradeToPRO.vue";
import ImportedItemLayout from "@/pages/ImportedItem/ImportedItemLayout.vue";
import SellingItem from "@/pages/SellingItem/SellingItemLayout.vue";
import Vendor from "@/pages/ImportedItem/Vendor.vue";
import Item from "@/pages/ImportedItem/Item.vue";
import Invoice from "@/pages/ImportedItem/Invoice.vue";


const routes = [{
    path: "/",
    component: DashboardLayout,
    redirect: "/dashboard",
    children: [{
            path: "dashboard",
            name: "Dashboard",
            component: Dashboard
        },
        {
            path: "user",
            name: "User Profile",
            component: UserProfile
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
            path: "maps",
            name: "Maps",
            meta: {
                hideFooter: true
            },
            component: Maps
        },
        {
            path: "notifications",
            name: "Notifications",
            component: Notifications
        },
        {
            path: "upgrade",
            name: "Upgrade to PRO",
            component: UpgradeToPRO
        }
    ]
}];

export default routes;