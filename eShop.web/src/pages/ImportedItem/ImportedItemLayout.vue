<template>
  <div class="content">
    <div class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-100">
      <md-tabs md-sync-route>
        <md-tab id="tab-vendor" md-label="Vendors" to="/importedItemLayout/vendor">
           <md-table v-model="users" >
            <thead>
              <th>ID</th>
              <th>Name</th>
              <th>Email</th>
              <th>Gender</th>
              <th>Job Title</th>
            </thead>

            <md-table-row slot="md-table-row" slot-scope="{ item }">
              <md-table-cell md-numeric>{{ item.id }}</md-table-cell>
              <md-table-cell>{{ item.name }}</md-table-cell>
              <md-table-cell>{{ item.email }}</md-table-cell>
              <md-table-cell>{{ item.gender }}</md-table-cell>
              <md-table-cell>{{ item.title }}</md-table-cell>
            </md-table-row>

            
          </md-table>
        </md-tab>

        <md-tab id="tab-item" md-label="Items" to="/importedItemLayout/item">
          <md-card>
            <md-card-header data-background-color="green">
              <h4 class="title">Simp</h4>
              <p class="category">Here is a subtitle for this table</p>
            </md-card-header>
            <md-card-content>
              <simple-table table-header-color="green"></simple-table>
            </md-card-content>
           </md-card>
        </md-tab>

        <md-tab id="tab-invoice" md-label="Invoice" to="/importedItemLayout/invoice">
        </md-tab>
    </md-tabs>
    <!-- <md-tabs>
      <md-tab><router-link to="/importedItemLayout/vendor">Vendors</router-link></md-tab>
      <router-link to="/importedItemLayout/item">Items</router-link>
      <router-link to="/importedItemLayout/invoice">Invoice</router-link>
    </md-tabs>
      
      <router-view></router-view> -->
    </div>
    
  </div>
</template>

<script>
  export default {
    name: 'ImportedItemLayout',
    data: () => ({
      users: [
        {
          id: 1,
          name: "Shawna Dubbin",
          email: "sdubbin0@geocities.com",
          gender: "Male",
          title: "Assistant Media Planner"
        },
        {
          id: 2,
          name: "Odette Demageard",
          email: "odemageard1@spotify.com",
          gender: "Female",
          title: "Account Coordinator"
        },
        {
          id: 3,
          name: "Vera Taleworth",
          email: "vtaleworth2@google.ca",
          gender: "Male",
          title: "Community Outreach Specialist"
        },
        {
          id: 4,
          name: "Lonnie Izkovitz",
          email: "lizkovitz3@youtu.be",
          gender: "Female",
          title: "Operator"
        },
        {
          id: 5,
          name: "Thatcher Stave",
          email: "tstave4@reference.com",
          gender: "Male",
          title: "Software Test Engineer III"
        },
        {
          id: 6,
          name: "Karim Chipping",
          email: "kchipping5@scribd.com",
          gender: "Female",
          title: "Safety Technician II"
        },
        {
          id: 7,
          name: "Helge Holyard",
          email: "hholyard6@howstuffworks.com",
          gender: "Female",
          title: "Internal Auditor"
        },
        {
          id: 8,
          name: "Rod Titterton",
          email: "rtitterton7@nydailynews.com",
          gender: "Male",
          title: "Technical Writer"
        },
        {
          id: 9,
          name: "Gawen Applewhite",
          email: "gapplewhite8@reverbnation.com",
          gender: "Female",
          title: "GIS Technical Architect"
        },
        {
          id: 10,
          name: "Nero Mulgrew",
          email: "nmulgrew9@plala.or.jp",
          gender: "Female",
          title: "Staff Scientist"
        },
        {
          id: 11,
          name: "Cybill Rimington",
          email: "crimingtona@usnews.com",
          gender: "Female",
          title: "Assistant Professor"
        },
        {
          id: 12,
          name: "Maureene Eggleson",
          email: "megglesonb@elpais.com",
          gender: "Male",
          title: "Recruiting Manager"
        },
        {
          id: 13,
          name: "Cortney Caulket",
          email: "ccaulketc@cbsnews.com",
          gender: "Male",
          title: "Safety Technician IV"
        },
        {
          id: 14,
          name: "Selig Swynfen",
          email: "sswynfend@cpanel.net",
          gender: "Female",
          title: "Environmental Specialist"
        },
        {
          id: 15,
          name: "Ingar Raggles",
          email: "iragglese@cbc.ca",
          gender: "Female",
          title: "VP Sales"
        },
        {
          id: 16,
          name: "Karmen Mines",
          email: "kminesf@topsy.com",
          gender: "Male",
          title: "Administrative Officer"
        },
        {
          id: 17,
          name: "Salome Judron",
          email: "sjudrong@jigsy.com",
          gender: "Male",
          title: "Staff Scientist"
        },
        {
          id: 18,
          name: "Clarinda Marieton",
          email: "cmarietonh@theatlantic.com",
          gender: "Male",
          title: "Paralegal"
        },
        {
          id: 19,
          name: "Paxon Lotterington",
          email: "plotteringtoni@netvibes.com",
          gender: "Female",
          title: "Marketing Assistant"
        },
        {
          id: 20,
          name: "Maura Thoms",
          email: "mthomsj@webeden.co.uk",
          gender: "Male",
          title: "Actuary"
        }
      ]
    })
  }
</script>