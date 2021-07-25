<template>

    <div class="col-xl-12 order-xl-1">
        <card shadow type="secondary">
            <div slot="header" class="bg-white border-0">
                <div class="row align-items-center">
                    <div class="col-8">
                        <h3 class="mb-0">Assign Role</h3>
                    </div>
                    <div class="col-4 text-right">
                        <a href="#!" class="btn btn-sm btn-primary">Settings</a>
                    </div>
                </div>
            </div>
            <template>
                <div class="pl-lg-4">
                    <div class="row">
                        <div class="col-lg-6">
                            <base-input alternative=""
                                        label="Username"
                                        placeholder="Username"
                                        input-classes="form-control-alternative"
                                        v-model="registerModel.user.user_name" />
                        </div>
                        <div class="col-lg-6">
                            <base-input alternative=""
                                        label="PassWord"
                                        placeholder="Password"
                                        input-classes="form-control-alternative"
                                        v-model="registerModel.user.pass_word" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <select class="custom-select" v-model="registerModel.user.employee_id">
                                <option selected>Choose employee code</option>
                                <option v-for="employee in listEmployee" 
                                        :value="employee.employee_id"
                                        :key="employee.employee_code">{{employee.employee_code}}</option>
                            </select>
                        </div>
                        <div class="col-lg-6">
                            <select class="custom-select" v-model="registerModel.roleId">
                                <option selected>Choose role</option>
                                <option v-for="role in listRole" 
                                        :value="role.role_id"
                                        :key="role.role_id">{{role.role_name}}</option>
                            </select>
                        </div>
                    </div>
                    <hr class="my-4" />
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <button class="btn btn-info" @click="handleSave">Save</button>
                        </div>
                    </div>
                </div>
            </template>
        </card>
    </div>
</template>
<script>
import {userService} from '../../service/userService.js';
import employeeService from '../../service/employeeService.js';

export default {
    name: 'AssignRole',
    data() {
        return {
            registerModel:{
                user: {},
                roleId: ''
            },
            listRole: [],
            listEmployee: [],
        }
    },
    methods: {
        async handleSave(){
            await userService.register(this.registerModel);
            //this.$router.push('system/users');
        },
        async initData(){
            var roleData = await userService.getRole(1,10);
            var employeeData = await employeeService.getEmployee(1,10);
            this.listRole = roleData.items;
            this.listEmployee = employeeData.items;
        }
    },
    created(){
        this.initData();
    }
}
</script>