<template>
    <div>
        <base-header class="header pb-8 pt-5 pt-lg-8 d-flex align-items-center"
                     style="min-height: 300px; background-image: url(img/theme/profile-cover.jpg); background-size: cover; background-position: center top;">
            <!-- Mask -->
            <span class="mask bg-gradient-success opacity-8"></span>
            <!-- Header container -->
            <div class="container-fluid d-flex align-items-center">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="display-2 text-white">Hello {{ model.name }}</h1>
                    </div>
                </div>
            </div>
        </base-header>

        <div class="container-fluid mt--7">
            <div class="row">
                <!-- <div class="col-xl-4 order-xl-2 mb-5 mb-xl-0">

                    <div class="card card-profile shadow">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <img src="img/theme/team-4-800x800.jpg" class="rounded-circle">
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <div class="d-flex justify-content-between">
                                <base-button size="sm" type="info" class="mr-4">Connect</base-button>
                                <base-button size="sm" type="default" class="float-right">Message</base-button>
                            </div>
                        </div>
                        <div class="card-body pt-0 pt-md-4">
                            <div class="row">
                                <div class="col">
                                    <div class="card-profile-stats d-flex justify-content-center mt-md-5">
                                        <div>
                                            <span class="heading">22</span>
                                            <span class="description">Friends</span>
                                        </div>
                                        <div>
                                            <span class="heading">10</span>
                                            <span class="description">Photos</span>
                                        </div>
                                        <div>
                                            <span class="heading">89</span>
                                            <span class="description">Comments</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center">
                                <h3>
                                    {{ model.name }}<span class="font-weight-light">, 27</span>
                                </h3>
                                <div class="h5 font-weight-300">
                                    <i class="ni location_pin mr-2"></i>Bucharest, Romania
                                </div>
                                <div class="h5 mt-4">
                                    <i class="ni business_briefcase-24 mr-2"></i>Solution Manager - Creative Tim Officer
                                </div>
                                <div>
                                    <i class="ni education_hat mr-2"></i>University of Computer Science
                                </div>
                                <hr class="my-4" />
                                <p>Ryan — the name taken by Melbourne-raised, Brooklyn-based Nick Murphy — writes, performs and records all of his own music.</p>
                                <a href="#">Show more</a>
                            </div>
                        </div>
                    </div>
                </div> -->

                <div class="col-xl-12 order-xl-1">
                    <card shadow type="secondary">
                        <div slot="header" class="bg-white border-0">
                            <div class="row align-items-center">
                                <div class="col-8">
                                    <h3 class="mb-0">My account</h3>
                                </div>
                                <div class="col-4 text-right">
                                    <a href="#!" class="btn btn-sm btn-primary">Settings</a>
                                </div>
                            </div>
                        </div>
                        <template>
                            <form @submit.prevent>
                                <h6 class="heading-small text-muted mb-4">User information</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        label="Username"
                                                        placeholder="Username"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.username" />
                                        </div>
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        label="Name"
                                                        placeholder="Name"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.name" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        label="Code"
                                                        placeholder="Code"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.code" />
                                        </div>
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        label="Indentify Number"
                                                        placeholder="Indentify Number"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.identifynumber" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 text-center">
                                            <button class="btn btn-info" @click="updateprofile">Save</button>
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-4" />
                                <!-- Password -->
                                <h6 class="heading-small text-muted mb-4">Update password</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        v-on:keyup="resetValidatePassword"
                                                        label="Current Password"
                                                        placeholder="Current Password"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.currentPassword" />
                                        </div>
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        v-on:keyup="resetValidatePassword"
                                                        label="New Password"
                                                        placeholder="New Password"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.newPassword" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 text-center">
                                            <button class="btn btn-info" @click="updatepassword">Update</button>    
                                            <div class="col-lg-12 text-center alert-danger mt-2">
                                                <p class="error" v-if="model.validatePassword">{{ model.validatePassword }}</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-4" />
                                <!-- Address -->
                                <h6 class="heading-small text-muted mb-4">Contact information</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <base-input alternative=""
                                                        label="Address"
                                                        placeholder="Home Address"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.address" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        label="Phone number"
                                                        placeholder="Phone number"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.phonenumber" />
                                        </div>
                                        <div class="col-lg-6">
                                            <base-input alternative=""
                                                        label="Email"
                                                        placeholder="Email"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.email" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 text-center">
                                            <button class="btn btn-info" @click="updateContacInformation">Save</button>
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-4" />
                                <!-- Description -->
                                <!-- <h6 class="heading-small text-muted mb-4">About me</h6>
                                <div class="pl-lg-4">
                                    <div class="form-group">
                                        <base-input alternative=""
                                                    label="About Me">
                                            <textarea rows="4" class="form-control form-control-alternative" placeholder="A few words about you ...">A beautiful Dashboard for Bootstrap 4. It is Free and Open Source.</textarea>
                                        </base-input>
                                    </div>
                                </div> -->
                                <!-- Other iformation -->
                                <h6 class="heading-small text-muted mb-4">Other information</h6>
                                <div class="pl-lg-4">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <base-input alternative=""
                                                        label="Shift"
                                                        placeholder="Shift"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.shift" />
                                        </div>
                                        <div class="col-md-3">
                                            <base-input alternative=""
                                                        label="Join date"
                                                        placeholder="join date"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.joindate" />
                                        </div>
                                        <div class="col-md-3">
                                            <base-input alternative=""
                                                        label="Group Name"
                                                        placeholder="Group Name"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.groupname" />
                                        </div>
                                        <div class="col-md-3">
                                            <base-input alternative=""
                                                        label="Base salary"
                                                        placeholder="Base salary"
                                                        input-classes="form-control-alternative"
                                                        v-model="model.basesalary" />
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </template>
                    </card>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
    import { mapActions } from "vuex";
    import profileService from '../../service/userProfileService/profileService.js';
    import utils from '../../helper/utils.js';
    export default {

        name: 'user-profile',
        mounted() {
            this.init()
        },
        data() {
            return {
                model: {
                    code: '',
                    name: '',
                    address: '',
                    phonemumber: '',
                    email: '',
                    identifynumber: '',
                    shift: '',
                    joindate: '',
                    groupname: '',
                    basesalary: '',
                    username: '',
                    newPassword: '',
                    currentUsername: '',
                    currentPassword: '',
                    validatePassword: '',
                }
            }
        },
        methods: {
            ...mapActions(["GetProfile"]),
            async init() {
                // var result = await this.GetProfile();

                // if (result) {
                //     this.model.username = result.email;
                //     this.model.name = result.name;
                //     this.model.currentUsername = result.email;
                // }
                // else {
                //     //no result must mean out token is missing or expired so force logout
                //     await this.$store.dispatch("LogOut");
                //     this.$router.push("/login");//redirect to dashboard route
                // }
                const loggedIn = localStorage.getItem('user');
                var user = JSON.parse(loggedIn);
                var userName = user.userName.toString();
                var result = await profileService.getProfile(userName);

                result.data.data[0].joindate = utils.converDateToString(result.data.data[0].joindate);
                result.data.data[0].basesalary = utils.converMoneyToString(result.data.data[0].basesalary);
                result.data.data[0].shift = utils.convertShift(result.data.data[0].shift);

                this.model = result.data.data[0];
                // this.model.joindate = dateString;
                // this.model.basesalary = salaryString;
                // this.model.shift = shift;
            },

            ...mapActions(["UpdateProfile"]),
            async updateprofile() {

                if (process.env.VUE_APP_ALLOW_PROFILE_UPDATE==='true') {

                    const profile = new FormData();
                    profile.append("currentusername", this.model.currentUsername);
                    profile.append("newusername", this.model.username);
                    profile.append("email", this.model.email);
                    profile.append("name", this.model.name);

                    var result = await this.UpdateProfile(profile);
                    if (result)
                        alert("Updated")

                    console.log(result);
                }
                else {
                    alert("Disabled in demo")
                }               
            },

            ...mapActions(["UpdatePassword"]),
            async updatepassword() {

                if (process.env.VUE_APP_ALLOW_PROFILE_UPDATE==='true') {

                    if (this.model.currentPassword != this.model.newPassword) {
                        this.model.validatePassword = 'Password must match';
                        return;
                    }

                    if (this.model.currentPassword.length == 0 || this.model.newPassword.length == 0) {
                        this.model.validatePassword = 'Password must have value';
                        return;
                    }

                    const password = new FormData();
                    password.append("currentPassword", this.model.currentPassword);
                    password.append("newPassword", this.model.newPassword);
                    password.append("userName", this.model.username);

                    var result = await this.UpdatePassword(password);
                    if (result) {
                        this.model.currentPassword = '';
                        this.model.newPassword = '';
                        alert("Updated")
                    }

                    console.log(result);
                }
                else {
                    alert("Disabled in demo")
                }    
            },

            resetValidatePassword() {
                this.model.validatePassword = "";
            },

            updateContacInformation(){

            },
        },
        created(){
            this.init();
        }
    };
</script>
<style></style>
