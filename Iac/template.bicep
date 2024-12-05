param sites_sb_csd_bp_name string = 'sb-csd-bp'
param serverfarms_sb_csd_plan_externalid string = '/subscriptions/ca190604-52a6-4995-bf81-ed45b383360c/resourceGroups/sb-csd-rg/providers/Microsoft.Web/serverfarms/sb-csd-plan'

resource sites_sb_csd_bp_name_resource 'Microsoft.Web/sites@2023-12-01' = {
  name: sites_sb_csd_bp_name
  location: 'North Europe'
  kind: 'app'
  properties: {
    enabled: true
    hostNameSslStates: [
      {
        name: '${sites_sb_csd_bp_name}.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Standard'
      }
      {
        name: '${sites_sb_csd_bp_name}.scm.azurewebsites.net'
        sslState: 'Disabled'
        hostType: 'Repository'
      }
    ]
    serverFarmId: serverfarms_sb_csd_plan_externalid
    reserved: false
    isXenon: false
    hyperV: false
    dnsConfiguration: {}
    vnetRouteAllEnabled: false
    vnetImagePullEnabled: false
    vnetContentShareEnabled: false
    siteConfig: {
      numberOfWorkers: 1
      acrUseManagedIdentityCreds: false
      alwaysOn: false
      http20Enabled: false
      functionAppScaleLimit: 0
      minimumElasticInstanceCount: 1
    }
    scmSiteAlsoStopped: false
    clientAffinityEnabled: true
    clientCertEnabled: false
    clientCertMode: 'Required'
    hostNamesDisabled: false
    vnetBackupRestoreEnabled: false
    customDomainVerificationId: '501588C518514574C3C6579341C8A95F27BC42DAF0B1B759187708F07C4DD5C5'
    containerSize: 0
    dailyMemoryTimeQuota: 0
    httpsOnly: true
    redundancyMode: 'None'
    publicNetworkAccess: 'Enabled'
    storageAccountRequired: false
    keyVaultReferenceIdentity: 'SystemAssigned'
  }
}

resource sites_sb_csd_bp_name_ftp 'Microsoft.Web/sites/basicPublishingCredentialsPolicies@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: 'ftp'
  location: 'North Europe'
  properties: {
    allow: true
  }
}

resource sites_sb_csd_bp_name_scm 'Microsoft.Web/sites/basicPublishingCredentialsPolicies@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: 'scm'
  location: 'North Europe'
  properties: {
    allow: true
  }
}

resource sites_sb_csd_bp_name_web 'Microsoft.Web/sites/config@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: 'web'
  location: 'North Europe'
  properties: {
    numberOfWorkers: 1
    defaultDocuments: [
      'Default.htm'
      'Default.html'
      'Default.asp'
      'index.htm'
      'index.html'
      'iisstart.htm'
      'default.aspx'
      'index.php'
      'hostingstart.html'
    ]
    netFrameworkVersion: 'v8.0'
    requestTracingEnabled: false
    remoteDebuggingEnabled: false
    remoteDebuggingVersion: 'VS2022'
    httpLoggingEnabled: false
    acrUseManagedIdentityCreds: false
    logsDirectorySizeLimit: 35
    detailedErrorLoggingEnabled: false
    publishingUsername: '$sb-csd-bp'
    scmType: 'None'
    use32BitWorkerProcess: true
    webSocketsEnabled: false
    alwaysOn: false
    managedPipelineMode: 'Integrated'
    virtualApplications: [
      {
        virtualPath: '/'
        physicalPath: 'site\\wwwroot'
        preloadEnabled: false
      }
    ]
    loadBalancing: 'LeastRequests'
    experiments: {
      rampUpRules: []
    }
    autoHealEnabled: false
    vnetRouteAllEnabled: false
    vnetPrivatePortsCount: 0
    publicNetworkAccess: 'Enabled'
    localMySqlEnabled: false
    ipSecurityRestrictions: [
      {
        ipAddress: 'Any'
        action: 'Allow'
        priority: 2147483647
        name: 'Allow all'
        description: 'Allow all access'
      }
    ]
    scmIpSecurityRestrictions: [
      {
        ipAddress: 'Any'
        action: 'Allow'
        priority: 2147483647
        name: 'Allow all'
        description: 'Allow all access'
      }
    ]
    scmIpSecurityRestrictionsUseMain: false
    http20Enabled: false
    minTlsVersion: '1.2'
    scmMinTlsVersion: '1.2'
    ftpsState: 'FtpsOnly'
    preWarmedInstanceCount: 0
    elasticWebAppScaleLimit: 0
    functionsRuntimeScaleMonitoringEnabled: false
    minimumElasticInstanceCount: 1
    azureStorageAccounts: {}
  }
}

resource sites_sb_csd_bp_name_002eb192c0b34bceb6f955864969c633 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '002eb192c0b34bceb6f955864969c633'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"ce489ed2fa4e76d1814f03273b93af92e5d3bdbd","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"try excluding files from coverage"}'
    start_time: '2024-12-05T02:28:21.2227009Z'
    end_time: '2024-12-05T02:28:24.3770743Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_0d07eaca82fc4be096e823ae18d382d8 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '0d07eaca82fc4be096e823ae18d382d8'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"2db28f20921b6bbac2b347a3bdca5a1a86479cd3","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"try again"}'
    start_time: '2024-12-05T02:35:43.8933914Z'
    end_time: '2024-12-05T02:35:47.1316076Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_0fc8b600b79f45f5a093e2ae6c326584 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '0fc8b600b79f45f5a093e2ae6c326584'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"43eb5fba974248afe669ded60a3c1981bd7cc4bf","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"try again"}'
    start_time: '2024-12-05T02:39:26.8126834Z'
    end_time: '2024-12-05T02:39:27.7214448Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_2975e0b9514a46d0b39f46ea2d0be288 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '2975e0b9514a46d0b39f46ea2d0be288'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"bf3b1d288b1ed1a7e6c0675a6e633737da4d3010","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"try replace"}'
    start_time: '2024-12-05T02:18:16.5018851Z'
    end_time: '2024-12-05T02:18:17.36145Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_3fc42d028d3d4fc98f195e11ce5470eb 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '3fc42d028d3d4fc98f195e11ce5470eb'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"ba4acf5117805a102e8180379ba8c5556c9c139e","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"try exclusion"}'
    start_time: '2024-12-05T02:25:07.6336971Z'
    end_time: '2024-12-05T02:25:10.3038942Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_4d7dccd8a74c4373ba29e4db22e6d677 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '4d7dccd8a74c4373ba29e4db22e6d677'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"8e2dd9f05391b54265e19de41eeb0bb584daffe6","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"trick sonar"}'
    start_time: '2024-12-05T01:32:51.5929375Z'
    end_time: '2024-12-05T01:32:54.578129Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_66946f76502c442581493baceda83ca3 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '66946f76502c442581493baceda83ca3'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"511b5995c9d22d1fb677c19aca9cfad9a38f2d58","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"update tip"}'
    start_time: '2024-12-05T02:46:03.4628077Z'
    end_time: '2024-12-05T02:46:06.7437155Z'
    active: true
  }
}

resource sites_sb_csd_bp_name_c59d96ca7be140acb90500d100afdbe6 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: 'c59d96ca7be140acb90500d100afdbe6'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"0752215a34a2dc4d3a731d47250b1ab4c8303743","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"ignore dev k6 script"}'
    start_time: '2024-12-05T01:36:14.2201643Z'
    end_time: '2024-12-05T01:36:17.4723218Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_da833b1096bb4c5faba0a57d2813eff1 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: 'da833b1096bb4c5faba0a57d2813eff1'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"4a4130dad3591065317711acc81d28bb65a6e6be","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"exclude performance"}'
    start_time: '2024-12-05T02:42:51.6746077Z'
    end_time: '2024-12-05T02:42:54.8614627Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_e3eb0df1ee6c48f590d4ecc0f1d2c684 'Microsoft.Web/sites/deployments@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: 'e3eb0df1ee6c48f590d4ecc0f1d2c684'
  location: 'North Europe'
  properties: {
    status: 4
    author_email: 'N/A'
    author: 'N/A'
    deployer: 'GITHUB_ZIP_DEPLOY'
    message: '{"type":"deployment","sha":"6e2ded05f6af434f15913bc4d123eec7c1091d42","repoName":"salob/bp","actor":"salob","slotName":"production","commitMessage":"try excludes again"}'
    start_time: '2024-12-05T02:32:49.6250221Z'
    end_time: '2024-12-05T02:32:52.3382515Z'
    active: false
  }
}

resource sites_sb_csd_bp_name_sites_sb_csd_bp_name_azurewebsites_net 'Microsoft.Web/sites/hostNameBindings@2023-12-01' = {
  parent: sites_sb_csd_bp_name_resource
  name: '${sites_sb_csd_bp_name}.azurewebsites.net'
  location: 'North Europe'
  properties: {
    siteName: 'sb-csd-bp'
    hostNameType: 'Verified'
  }
}
